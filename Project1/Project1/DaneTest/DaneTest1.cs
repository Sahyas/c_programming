using NUnit.Framework;
using Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaneTest
{
    public class DataTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void SpeedSetterTest()
        {
            DaneAbstractAPI api = DaneAbstractAPI.CreateDataApi();

            api.createBalls(3);

            Assert.AreEqual(api.getBallsAmount(), 3);
        }
    }
}