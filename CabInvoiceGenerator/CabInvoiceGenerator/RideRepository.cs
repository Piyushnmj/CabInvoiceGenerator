using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> objUserRides = null;

        /// <summary>
        /// Constructor to create Dictionary
        /// </summary>
        public RideRepository()
        {
            this.objUserRides = new Dictionary<string, List<Ride>>();
        }

        /// <summary>
        /// Function to Add Ride Listto specified UserID
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <param name="rides">The rides.</param>
        public void AddRide(string userID, Ride[] rides)
        {
            bool rideList = this.objUserRides.ContainsKey(userID);
            try
            {
                if(!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.objUserRides.Add(userID, list);
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Ride are Null");
            }
        }

        public Ride[] GetRides(string UserID)
        {
            try
            {
                return this.objUserRides[UserID].ToArray();
            }
            catch (Exception)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid UserID");
            }
        }
    }
}
