using Logika;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;

namespace Model
{
    public interface IBall : INotifyPropertyChanged
    {
        double Top { get; }
        double Left { get; }
        int Diameter { get; }
    }

    public class BallChaneEventArgs : EventArgs
    {
        public IBall Ball { get; set; }
    }

    public abstract class ModelAPI : IObservable<IBall>
    {
        public static ModelAPI CreateApi()
        {
            return new ModelBall();
        }

        public abstract void AddBallsAndStart(int ballsAmount);

        #region IObservable

        public abstract IDisposable Subscribe(IObserver<IBall> observer);

        #endregion IObservable

        internal class ModelBall : ModelAPI
        {
            private LogicAPI logicApi;
            public event EventHandler<BallChaneEventArgs> BallChanged;

            private IObservable<EventPattern<BallChaneEventArgs>> eventObservable = null;
            private List<BallInModel> Balls = new List<BallInModel>();

            public ModelBall()
            {
                logicApi = logicApi ?? LogicAPI.CreateLayer();
                IDisposable observer = logicApi.Subscribe(x => Balls[x.id - 1].Move(x.positionX, x.positionY));
                eventObservable = Observable.FromEventPattern<BallChaneEventArgs>(this, "BallChanged");
            }

            public override void AddBallsAndStart(int ballsAmount)
            {
                logicApi.AddBallsAndStart(ballsAmount);
                for (int i = 1; i <= ballsAmount; i++)
                {
                    BallInModel newBall = new BallInModel(logicApi.getBallpositionX(i), logicApi.getBallpositionY(i), logicApi.getBallRadius(i));
                    Balls.Add(newBall);
                }

                foreach (BallInModel ball in Balls)
                {
                    BallChanged?.Invoke(this, new BallChaneEventArgs() { Ball = ball });
                }

            }

            public override IDisposable Subscribe(IObserver<IBall> observer)
            {
                return eventObservable.Subscribe(x => observer.OnNext(x.EventArgs.Ball), ex => observer.OnError(ex), () => observer.OnCompleted());
            }
        }
    }
}