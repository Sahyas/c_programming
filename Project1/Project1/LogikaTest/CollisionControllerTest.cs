using NUnit.Framework;
using Logika;
using System;
using Dane;


namespace LogikaTest
{
    public class CollisionControllerTest
    {
        public class Ball : IBall
        {
            public int id { get; }

            public Ball(double x, double y, double moveX, double moveY, int radius)
            {
                positionX = x;
                positionY = y;
                Radius = radius;
                shiftX = moveX;
                shiftY = moveY;
            }

            public double positionX { get; }
            public double positionY { get; }

            public int Radius { get; }
            public double Mass { get; }

            public double speedX { get; set; }
            public double speedY { get; set; }

            public double shiftX { get; set; }
            public double shiftY { get; set; }

            public IDisposable Subscribe(IObserver<IBall> observer)
            {
                throw new NotImplementedException();
            }
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CollisionTest()
        {
            IBall ball = new Ball(1, 1, 5, 5, 10);
            IBall ball2 = new Ball(21, 1, 5, 5, 10);
            Assert.IsTrue(CollisionControler.IsCollision(ball, ball2));
            ball2 = new Ball(20, 1, 5, 5, 10);
            Assert.IsTrue(CollisionControler.IsCollision(ball, ball2));

            ball2 = new Ball(26, 1, 5, 5, 10);
            Assert.IsFalse(CollisionControler.IsCollision(ball, ball2));
        }

        [Test]
        public void XYBoundaryTest()
        {
            IBall ball = new Ball(1, 1, 5, 5, 10);
            double speedX = ball.speedX;
            double speedY = ball.speedY;

            CollisionControler.IsTouchingBoundaries(ball, 100);

            Assert.AreEqual(-speedX, ball.speedX);
            Assert.AreEqual(-speedY, ball.speedY);
        }
    }
}