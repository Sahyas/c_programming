using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logika
{
    public class Board
    {
        public int size { get; set; }
        public List<Ball> balls { get; set; }
        private Task updatePosition;
        private int speed = 30;

        public Board(int size)
        {
            this.size = size;
        }

        public void addBalls(int BallsNumber)
        {
            balls = new List<Ball>();
            for (int i = 0; i < BallsNumber; i++)
            {
                balls.Add(new Ball());
            }
        }

        // balls remove - dodane
        public void removeBalls(int BallsNumber)
        {
            balls = new List<Ball>();
            for (int i = 0; i < BallsNumber; i++)
            {
                balls.RemoveAt(i);
            }
        }
       
        public void MoveBalls()
        {
                foreach (Ball ball in balls)
                {
                ball.changeBallPosition(size);
                }
        }

        public void MoveBallsConstantly()
        {
            while (true)
            {
                MoveBalls();
                Thread.Sleep(speed);
            }
        }

        public void start()
        {
            updatePosition = new Task(MoveBallsConstantly);
            updatePosition.Start();
        }
    }
}
