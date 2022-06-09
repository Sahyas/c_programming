using NUnit.Framework;
using Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaneTest
{
    public class BallTest
    {
        [SetUp]
        public void Setup()
        {
            /*Ball Ball = new Ball(1);
            double pX = Ball.positionX;
            double pY = Ball.positionY;
            Assert.AreEqual(Ball.positionX, pX + Ball.shiftX);
            Assert.AreEqual(Ball.positionY, pY + Ball.shiftY);*/
            Ball ball = new Ball(1);
            double pX = ball.positionX;
            double pY = ball.positionY;
            ball.ChangeBallPosition(0);
            Assert.AreEqual(ball.positionX, pX + ball.speedX / 5);
            Assert.AreEqual(ball.positionY, pY + ball.speedY / 5);
            pX = ball.positionX;
            pY = ball.positionY;
            ball.ChangeBallPosition(2);
            Assert.AreEqual(ball.positionX, pX + (ball.speedX / 5) * 2);
            Assert.AreEqual(ball.positionY, pY + (ball.speedY / 5) * 2);
        }

        [Test]
        public void PositionTest()
        {
            /*Ball Ball = new Ball(1);
            Assert.IsTrue(Ball.positionX <= 500 && Ball.positionX >= 1);
            Assert.IsTrue(Ball.positionY <= 500 && Ball.positionY >= 1);
            Assert.IsTrue(Ball.shiftX <= 5 && Ball.shiftX >= 3);
            Assert.IsTrue(Ball.shiftY <= 5 && Ball.shiftY >= 3);*/
            Ball ball = new Ball(1);
            Assert.IsTrue(ball.positionX <= 500 && ball.positionY >= 1);
            Assert.IsTrue(ball.positionY <= 500 && ball.positionY >= 1);
        }
    }
}