using System;
using System.Collections.Generic;
using System.Threading;

namespace Dane
{
    public abstract class DaneAbstractAPI : IObserver<IBall>, IObservable<IBall>
    {
        public abstract double getBallpositionX(int ballId);
        public abstract double getBallpositionY(int ballId);
        public abstract int getBallRadius(int ballId);
        public abstract double getBallspeedX(int ballId);
        public abstract double getBallspeedY(int ballId);
        public abstract double getBallMass(int ballId);
        public abstract int getBoardSize();
        public abstract void setBallSpeed(int ballId, double speedX, double speedY);
        public abstract void createBalls(int ballsAmount);
        public abstract int getBallsAmount();
        public abstract void OnCompleted();
        public abstract void OnError(Exception error);
        public abstract void OnNext(IBall value);
        public abstract IDisposable Subscribe(IObserver<IBall> observer);
        public static DaneAbstractAPI CreateDataApi()
        {
            return new DaneApi();
        }
                public class BallChaneEventArgs : EventArgs
        {
            public IBall newBall { get; set; }
        }
    }

        public class DaneApi : DaneAbstractAPI
        {
            private BallRepository ballRepository;
            private IDisposable unsubscriber;
            static object _lock = new object();
            private IList<IObserver<IBall>> observers;
            private Barrier barrier;

            public DaneApi()
            {
                this.ballRepository = new BallRepository();

                observers = new List<IObserver<IBall>>();
            }

            public override double getBallpositionX(int ballId)
            {
                return this.ballRepository.getBall(ballId).positionX;
            }

            public override double getBallpositionY(int ballId)
            {
                return this.ballRepository.getBall(ballId).positionY;
            }

            public override int getBoardSize()
            {
                return ballRepository.boardSize;
            }

            public override double getBallMass(int ballId)
            {
                return this.ballRepository.getBall(ballId).Mass;
            }

            public override int getBallRadius(int ballId)
            {
                return this.ballRepository.getBall(ballId).Radius;
            }

            public override double getBallspeedX(int ballId)
            {
                return this.ballRepository.getBall(ballId).shiftX;
            }

            public override double getBallspeedY(int ballId)
            {
                return this.ballRepository.getBall(ballId).shiftY;
            }

            public override void setBallSpeed(int ballId, double speedX, double speedY)
            {
                this.ballRepository.getBall(ballId).shiftX = speedX;
                this.ballRepository.getBall(ballId).shiftY = speedY;
            }

            public override int getBallsAmount()
            {
                return ballRepository.balls.Count;
            }

            public override void createBalls(int ballsAmount)
            {
                barrier = new Barrier(ballsAmount);
                ballRepository.createBalls(ballsAmount);

                foreach (var ball in ballRepository.balls)
                {
                    Subscribe(ball);
                    ball.StartMoving();
                }

            }

            #region observer

            public virtual void Subscribe(IObservable<IBall> provider)
            {
                if (provider != null)
                    unsubscriber = provider.Subscribe(this);
            }

            public override void OnCompleted()
            {
                Unsubscribe();
            }

            public override void OnError(Exception error)
            {
                throw error;
            }


            public virtual void Unsubscribe()
            {
                unsubscriber.Dispose();
            }

            #endregion

            #region provider

            public override IDisposable Subscribe(IObserver<IBall> observer)
            {
                if (!observers.Contains(observer))
                    observers.Add(observer);
                return new Unsubscriber(observers, observer);
            }

        public override void OnNext(IBall value)
        {
            barrier.SignalAndWait();

            foreach (var observer in observers)
            {
                observer.OnNext(value);
            }

        }

        private class Unsubscriber : IDisposable
            {
                private IList<IObserver<IBall>> _observers;
                private IObserver<IBall> _observer;

                public Unsubscriber
                (IList<IObserver<IBall>> observers, IObserver<IBall> observer)
                {
                    _observers = observers;
                    _observer = observer;
                }

                public void Dispose()
                {
                    if (_observer != null && _observers.Contains(_observer))
                        _observers.Remove(_observer);
                }
            }

            #endregion
        }
    }
