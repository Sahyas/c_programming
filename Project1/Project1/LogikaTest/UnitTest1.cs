using NUnit.Framework;
using Logika;

namespace LogikaTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Ball ball = new Ball();

            double positionX = ball.positionX;
            double positionY = ball.positionY;
            ball.changeBallPosition(545);
            Assert.AreEqual(ball.positionX, positionX + ball.shiftX);
            Assert.AreEqual(ball.positionY, positionY + ball.shiftY);
        }

        [Test]
        public void Test1()
        {
            Ball ball = new Ball();

            Assert.IsTrue(ball.positionX <= 500 && ball.positionX >= 1);
            Assert.IsTrue(ball.positionY <= 500 && ball.positionY >= 1);

            Assert.IsTrue(ball.shiftX <= 5 && ball.shiftX >= 1);
            Assert.IsTrue(ball.shiftY <= 5 && ball.shiftY >= 1);
        }
    }
} 