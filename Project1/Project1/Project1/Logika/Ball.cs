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
         
            positionX = generateRandomDouble(1, 500);
            positionY = generateRandomDouble(1, 500);

            shiftX = generateRandomDouble(0, 3);
            shiftY = generateRandomDouble(0, 3);
        }

        public void changeBallPosition(int edge)
        {
            double tmpX = positionX + shiftX;
            double tmpY = positionY + shiftY;

            if(tmpX > edge - 12.5 || tmpX < 0)
            {
                shiftX = -shiftX;
            }
            if(tmpY > edge - 12.5 || tmpY < 0)
            {
                shiftY = -shiftY;
            }

            double x = positionX + shiftX;
            double y = positionY + shiftY;

            positionX = x;
            positionY = y;
        }
    };
}
