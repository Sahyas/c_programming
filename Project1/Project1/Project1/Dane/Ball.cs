using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dane
{
    public class Ball : IBall
    {
        public int id { get; }
        public double positionX { get; private set; }
        public double positionY { get; private set; }
        public double shiftX { get; set; }
        public double shiftY { get; set; }
        public double speedX { get; set; }
        public double speedY { get; set; }
        public int Radius { get; } = 12;
        public double Mass { get; } = 10;
        public int counter { get; set; } = 1;
        public bool isRunning = true;
        internal readonly IList<IObserver<IBall>> observers;

        private Task BallThread;
        Stopwatch stopwatch;
        Random rng = new Random();

        internal Logger dao { get; set; }

        public double generateRandomDouble(double min, double max)
        {
            return rng.NextDouble() * (max - min) + min;
        }

        public Ball(int id)
        {
            this.id = id;
            observers = new List<IObserver<IBall>>();
            stopwatch = new Stopwatch();

            this.positionX = generateRandomDouble(1, 500);
            this.positionY = generateRandomDouble(1, 500);

            this.speedX = generateRandomDouble(0.2, 0)/5;
            this.speedY = generateRandomDouble(0.2, 0)/5;
        }

        public void StartMoving()
        {
            this.BallThread = new Task(MoveBall);
            BallThread.Start();
        }

        public void MoveBall()
        {
            while (isRunning)
            {
                long time = stopwatch.ElapsedMilliseconds;
                counter++;

                stopwatch.Restart();
                stopwatch.Start();
                ChangeBallPosition(time);
                if (counter % 2000 == 0)
                {
                    dao.addToBuffer(this);
                    counter = 1;
                }

                foreach (var observer in observers.ToList())
                {
                    if (observer != null)
                    {
                        observer.OnNext(this);
                    }
                }
                stopwatch.Stop();
            }
        }

        public void ChangeBallPosition(long time)
        {

            if (time > 0)
            { 
                shiftX = speedX /5 * time;
                shiftY = speedY /5 * time;
            }
            else
            {
                shiftX = speedX /5;
                shiftY = speedY /5;
            }

            positionX += shiftX;
            positionY += shiftY;
        }

        public IDisposable Subscribe(IObserver<IBall> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
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
    }
}
