namespace TestParkTest
{
    [TestClass]
    public class ParkingTest
    {
        [TestMethod]
        public void TestCheckOut()
        {
            int expected = 5;

            int result = ParkeringsAppLunchTrion.Helpers.CheckOut(5,10);

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void TestExtendTime()
        {
            int expected = 10;

            int result = ParkeringsAppLunchTrion.Helpers.ExtendTime(5,5);

            Assert.AreEqual(expected, result);
        }
    }
}