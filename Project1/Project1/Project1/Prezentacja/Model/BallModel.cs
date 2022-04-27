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

        public double X
        {
            get { return this.ball.positionX; }
        }

        public double Y
        {
            get { return this.ball.positionY; }
        }

    }
}
