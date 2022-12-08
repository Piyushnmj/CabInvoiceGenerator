using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    /// <summary>
    /// Ride Class to Set Data for Particular Ride
    /// </summary>
    public class Ride
    {
        
        public double distance;
        public int time;

        /// <summary>
        /// Parameter Constructor for Setting Data
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="time">The time.</param>
        public Ride(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
