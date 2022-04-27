using System;

namespace Logika
{
    public class Ball
    {
        public double positionX { get; set; }
        public double positionY { get; set; }
        public double shiftX { get; set; }
        public double shiftY { get; set; }

        public Random rng = new Random();

        public double generateRandomDouble(double min, double max)
        {
            return rng.NextDouble() * (max - min) + min;
        }

        public Ball()
        {
            positionX = generateRandomDouble(0, 100);
            positionY = generateRandomDouble(0, 100);

            shiftX = generateRandomDouble(0, 2);
            shiftY = generateRandomDouble(0, 2);
        }

        public void changeBallPosition(int edge)
        {
            double x = positionX + shiftX;
            double y = positionY + shiftY;

            if(x > edge || y < edge)
            {
                shiftX = -shiftX;
            }
            if(y > edge || x < edge)
            {
                shiftY = -shiftY;
            }

            positionX = x;
            positionY = y;
        }
    };
}
