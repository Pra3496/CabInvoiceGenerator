using CabInvoiceGenerator;
namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;

        // UC1 : Test case for checking total fare function.
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {

            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;

            // Calculating Fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;

            // Asserting Values
            Assert.AreEqual(expected, fare);
        }


        // UC2 : Test case for calculate fare function for multiple rides summary.

        [Test]
        public void GivenMultipleRidesShouldReturnInvoiceSummary()
        {

            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            //Act
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);

            //Assert
            Assert.AreEqual(expectedSummary, summary);
        }

       
    }
}