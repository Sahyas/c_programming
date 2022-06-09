using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using Dane;

namespace Logika
{
    public abstract class LogicAPI : IObserver<IBall>, IObservable<IBall>
    {
        public abstract void AddBallsAndStart(int BallsAmount);
        public abstract double getBallpositionX(int ballId);
        public abstract double getBallpositionY(int ballId);
        public abstract int getBallRadius(int ballId);

        public abstract IDisposable Subscribe(IObserver<IBall> observer);
        public abstract void OnCompleted();
        public abstract void OnError(Exception error);
        public abstract void OnNext(IBall value);
        Dictionary<int, IBall> ballTree;


        public static LogicAPI CreateLayer(DaneAbstractAPI data = default(DaneAbstractAPI))
        {
            return new BusinessLogic(data == null ? DaneAbstractAPI.CreateDataApi() : data);
        }

        public class BallChaneEventArgs : EventArgs
        {
            public IBall ball { get; set; }
        }

        private class BusinessLogic : LogicAPI, IObservable<IBall>
        {
            private readonly DaneAbstractAPI dataAPI;
            private IDisposable unsubscriber;
            static object _lock = new object();
            private IObservable<EventPattern<BallChaneEventArgs>> eventObservable = null;
            public event EventHandler<BallChaneEventArgs> BallChanged;

            public BusinessLogic(DaneAbstractAPI dataAPI)
            {
                eventObservable = Observable.FromEventPattern<BallChaneEventArgs>(this, "BallChanged");
                this.dataAPI = dataAPI;
                Subscribe(dataAPI);
                ballTree = new Dictionary<int, IBall>();
            }

            public override double getBallpositionX(int ballId)
            {
                return this.dataAPI.getBallpositionX(ballId);
            }

            public override double getBallpositionY(int ballId)
            {
                return this.dataAPI.getBallpositionY(ballId);
            }

            public override int getBallRadius(int ballId)
            {
                return this.dataAPI.getBallRadius(ballId);
            }


            public override void AddBallsAndStart(int BallsAmount)
            {
                dataAPI.createBalls(BallsAmount);
            }

            #region observer

            public virtual void Subscribe(IObservable<IBall> provider)
            {
                if (provider != null)
                    unsubscriber = provider.Subscribe(this);
            }

            public override void OnNext(IBall ball)
            {
                Monitor.Enter(_lock);
                try
                {
                    if (!ballTree.ContainsKey(ball.id))
                    {
                        ballTree.Add(ball.id, ball);
                    }

                    foreach (var item in ballTree)
                    {
                        if (item.Key != ball.id)
                        {
                            if (CollisionControler.IsCollision(ball, item.Value))
                            {
                                CollisionControler.ImpulseSpeed(ball, item.Value);
                            }
                        }
                    }

                    CollisionControler.IsTouchingBoundaries(ball, dataAPI.getBoardSize());

                    BallChanged?.Invoke(this, new BallChaneEventArgs() { ball = ball });

                }
                catch (SynchronizationLockException exception)
                {
                    throw new Exception("Checking collision synchronization lock not working", exception);
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
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

            #region observable
            public override IDisposable Subscribe(IObserver<IBall> observer)
            {
                return eventObservable.Subscribe(x => observer.OnNext(x.EventArgs.ball), ex => observer.OnError(ex), () => observer.OnCompleted());
            }
            #endregion

        }
    }
}