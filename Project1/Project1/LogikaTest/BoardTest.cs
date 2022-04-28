using NUnit.Framework;
using Logika;

namespace LogikaTest
{
    public class BoardTest
    {
        [SetUp]
        public void Setup()
        {
            Board board = new Board(550);

            board.addBalls(1);
            Assert.AreEqual(board.balls.Count, 1);  
        }

        [Test]
        public void Test1()
        {
            Board board = new Board(100);

            board.addBalls(2);

            double pX1 = board.balls[0].positionX;
            double pY1 = board.balls[0].positionY;  

            double pX2 = board.balls[1].positionX;
            double pY2 = board.balls[1].positionY;

            board.MoveBalls();

            Assert.AreNotEqual(board.balls[0].positionX, pX1);
            Assert.AreNotEqual(board.balls[0].positionY, pY1);
            Assert.AreNotEqual(board.balls[1].positionX, pX2);
            Assert.AreNotEqual(board.balls[1].positionY, pY2);
        }
    }
}
