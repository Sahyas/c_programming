using Logika;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class BallModel
    {
        private Ball ball;

        public BallModel(Ball ball)
        {
            this.ball = ball;
        }

        private double positionX;

        public double X
        {
            get { return ball.positionX; }
        }

        private double positionY;
        public double Y
        {
            get { return ball.positionY; }
        }

    }
}
