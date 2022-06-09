using NUnit.Framework;
using Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaneTest
{
    public class RepoTest
    {
        [SetUp]
        public void Setup()
        {
            BallRepository repo = new BallRepository();
            repo.createBalls(5);

            Assert.AreEqual(repo.balls.Count, 5);
            Assert.AreEqual(repo.balls[0].id, 1);
            Assert.AreEqual(repo.balls[1].id, 2);
            Assert.AreEqual(repo.balls[2].id, 3);
            Assert.AreEqual(repo.balls[3].id, 4);
            Assert.AreEqual(repo.balls[4].id, 5);
        }

        [Test]
        public void getBallsTest()
        {
            BallRepository repo = new BallRepository();
            repo.createBalls(5);
            Assert.AreEqual(repo.getBall(1), repo.balls[0]);
            Assert.AreEqual(repo.getBall(2), repo.balls[1]);
            Assert.AreEqual(repo.getBall(3), repo.balls[2]);
            Assert.AreEqual(repo.getBall(4), repo.balls[3]);
            Assert.AreEqual(repo.getBall(5), repo.balls[4]);
        }
    }
}