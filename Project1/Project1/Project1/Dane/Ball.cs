using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class Ball : IObservable<int>
    {
        public int id { get; }
        public double positionX { get; private set; }
        public double positionY { get; private set; }
        public double shiftX { get; set; }
        public double shiftY { get; set; }
        public int Radius { get; } = 20;
        public double Mass { get; } = 10;
        internal readonly IList<IObserver<int>> observers;

        private Task BallThread;

        Random rng = new Random();

        public double generateRandomDouble(double min, double max)
        {
            return rng.NextDouble() * (max - min) + min;
        }

        public Ball(int id)
        {
            this.id = id;
            observers = new List<IObserver<int>>();

            this.positionX = generateRandomDouble(1, 500);
            this.positionY = generateRandomDouble(1, 500);

            this.shiftX = generateRandomDouble(0, 3);
            this.shiftY = generateRandomDouble(0, 3);
        }
        public void StartMoving()
        {
            this.BallThread = new Task(MoveBall);
            BallThread.Start();
        }

        public void MoveBall()
        {
            while (true)
            {
                changeBallPosition();

                foreach ( var observer in observers.ToList())
                {
                    if( observer != null)
                    {
                        observer.OnNext(id);
                    }
                }
                System.Threading.Thread.Sleep(1);
            }
        }

        public void changeBallPosition()
        {
            positionX += shiftX;
            positionY += shiftY;
        }

        public IDisposable Subscribe(IObserver<int> observer)
        {
            throw new NotImplementedException();
        }
    }
}
