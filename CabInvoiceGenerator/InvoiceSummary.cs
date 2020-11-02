using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
   public class InvoiceSummary
    {
        public int noOfRides;
        public double totalFare;
        public double averageFare;

        public InvoiceSummary(int noOfRides, double totalFare)
        {
            this.noOfRides = noOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.noOfRides;
        }

        /// <summary>
        /// Overriding Equals Method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is InvoiceSummary))
            {
                return false;
            }

            InvoiceSummary invoiceSummary = (InvoiceSummary)obj;
            return this.noOfRides == invoiceSummary.noOfRides && this.totalFare == invoiceSummary.totalFare && this.averageFare == invoiceSummary.averageFare;
        }

        /// <summary>
        /// Calculating Hashcode of every object by XORing hashcode of every variable 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.noOfRides.GetHashCode() ^ this.totalFare.GetHashCode() ^ this.averageFare.GetHashCode();
        }
    }
}
