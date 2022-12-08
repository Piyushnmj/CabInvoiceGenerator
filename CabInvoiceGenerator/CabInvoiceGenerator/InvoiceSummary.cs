using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        private int numOfRides;
        private double totalFare;
        private double averageFare;

        /// <summary>
        /// Parameter constructor for setting data
        /// </summary>
        /// <param name="numOfRides">The number of rides.</param>
        /// <param name="totalFare">The total fare.</param>
        public InvoiceSummary(int numOfRides, double totalFare)
        {
            this.numOfRides = numOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numOfRides;
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

            InvoiceSummary inputedObject = (InvoiceSummary)obj;
            return this.numOfRides == inputedObject.numOfRides && this.totalFare == inputedObject.totalFare && this.averageFare == inputedObject.averageFare;
        }

        public override int GetHashCode()
        {
            return this.numOfRides.GetHashCode() ^ this.totalFare.GetHashCode() ^ this.averageFare.GetHashCode();
        }
    }
}
