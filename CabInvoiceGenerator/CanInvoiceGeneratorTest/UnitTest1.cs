using CabInvoiceGenerator;

namespace CanInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator objInvoiceGenerator = null;

        /// <summary>
        /// Test Case for checking Calculate fare function
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ReturnTotalFare()
        {
            objInvoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;

            double fare = objInvoiceGenerator.CalculateFare(distance, time);
            double expected = 25;

            Assert.AreEqual(expected, fare);
        }

        /// <summary>
        /// Test case for checking Calculate Fare function for multiple rides summary
        /// </summary>
        [Test]
        public void GivenMultipleRides_ReturnInvoiceSummary()
        {
            objInvoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = objInvoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);

            Assert.AreEqual(expectedSummary, summary);
        }
    }
}