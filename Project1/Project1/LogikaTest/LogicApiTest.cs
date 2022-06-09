using NUnit.Framework;
using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogikaTest
{
    internal class LogicAPITest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CollisionTest()
        {
            LogicAPI logic = LogicAPI.CreateLayer();
            logic.AddBallsAndStart(1);
        }
    }
}
