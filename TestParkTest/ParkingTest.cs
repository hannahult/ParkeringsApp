using ParkeringsAppLunchTrion;

namespace TestParkTest
{
    [TestClass]
    public class ParkingTest
    {

        [TestMethod]
        public void TestExtendTime()
        {
            int expected = 10;

            int result = ParkeringsAppLunchTrion.Helpers.ExtendTime(5,5);

            Assert.AreEqual(expected, result);
        }


        //Gamla testmetoden för kostnadsuträkning (innan vi la till deluxeparkeringar)
        [TestMethod]
        public void TestCalculateCost()
        {
            double expected = 15;
            double result = ParkeringsAppLunchTrion.Helpers.CalculateCost(10);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestAddNumberOfVehicles()
        {
            int expected = 4;
            int result = ParkeringsAppLunchTrion.Helpers.AddNumberOfVehicles(3);
            Assert.AreEqual(expected, result);
        }
    }
}