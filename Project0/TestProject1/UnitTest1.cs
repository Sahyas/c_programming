using Microsoft.VisualStudio.TestTools.UnitTesting;

using ClassLibrary;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Class1 testClass = new Class1();
            double a = 3;
            double b = 2;
            double c = 1;
            double addResult = testClass.Add(a, b, c);
            Assert.AreEqual(addResult, 6);
            double subResult = testClass.Sub(a, b, c);
            Assert.AreEqual(subResult, 0);
            double multResult = testClass.Mult(a, b, c);
            Assert.AreEqual(multResult, 6);
            double divResult = testClass.Div(a, b, c);
            Assert.AreEqual(divResult, 1.5);
        }
    }
}