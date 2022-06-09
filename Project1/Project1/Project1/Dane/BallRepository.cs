using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public class BallRepository
    {
        public List<Ball> balls { get; set; }
        public int boardSize { get; set; } = 555;
        Logger dao;

        public BallRepository()
        {
            balls = new List<Ball>();
            dao = new Logger();
        }

        public void createBalls(int amount)
        {
            for(int i = 0; i < amount; i++)
            {
                Ball newBall = new Ball(i + 1);
                balls.Add(newBall);
                newBall.dao = dao;
            }
        }

        public Ball getBall(int id)
        {
            return balls[id - 1];
        }
    }
}
