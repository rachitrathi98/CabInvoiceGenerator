using CabInvoiceGenerator;
using NUnit.Framework;
using System;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator;
        /// <summary>
        /// TC1 Calculate and Test Fare for the ride 
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);

            double expected = 25;
            double distance = 2;
            int time = 5;

            double actual = invoiceGenerator.CalculateFare(distance, time);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// TC2 Compare Invoice Summary For Multiple Rides
        /// </summary>
        [Test]
        public void GivenMultipleRidesShouldReturnInvoiceSummary()
        {
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);

            InvoiceSummary acutalSummary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);

            Assert.AreEqual(expectedSummary, acutalSummary);
        }

        /// <summary>
        /// TC3
        /// </summary>
        [Test]
        public void GivenMultipleRidesShouldReturnTotalRides_Fare_AverageFare()
        {
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1), new Ride(1, 5) };
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);

            InvoiceSummary actualSummary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(3, 45.0); 
            Assert.AreEqual(actualSummary, expectedSummary);
        }

        /// <summary>
        /// TC4
        /// </summary>
        [Test]
        public void GivenUserIdCompareRidesFromRideRepository()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            invoiceGenerator.AddRide("Rachit", new Ride[] { new Ride(3, 10), new Ride(1, 5) });
            invoiceGenerator.AddRide("Rathi", new Ride[] { new Ride(4, 25), new Ride(2, 15) });

            InvoiceSummary actualInvoice = invoiceGenerator.GetInvoiceSummary("Rachit");

            InvoiceSummary expectedInvoice = invoiceGenerator.CalculateFare(new Ride[] { new Ride(3, 10), new Ride(1, 5) });

            Assert.AreEqual(expectedInvoice, actualInvoice);

        }

        /// <summary>
        /// TC5
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFarePremium()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);

            double expected = 40;
            double distance = 2;
            int time = 5;

            double actual = invoiceGenerator.CalculateFare(distance, time);

            Assert.AreEqual(expected, actual);

        }

    }
}