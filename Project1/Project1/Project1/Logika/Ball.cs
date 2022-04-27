using System;

namespace Logika
{
    public class Ball
    {
        public double positionX { get; private set; }
        public double positionY { get; private set; }
        public double shiftX { get; private set; }
        public double shiftY { get; private set; }

        Random rng = new Random();

        public double generateRandomDouble(double min, double max)
        {
            return rng.NextDouble() * (max - min) + min;
        }

        public Ball()
        {
         
            positionX = generateRandomDouble(1, 100);
            positionY = generateRandomDouble(1, 100);

            shiftX = generateRandomDouble(1, 2);
            shiftY = generateRandomDouble(1, 2);
        }

        public void changeBallPosition(int edge)
        {
            double x = positionX + shiftX;
            double y = positionY + shiftY;

            if(x > edge || x < 0)
            {
                shiftX = -shiftX;
            }
            if(y > edge || y < 0)
            {
                shiftY = -shiftY;
            }

            positionX = x;
            positionY = y;
        }
    };
}
