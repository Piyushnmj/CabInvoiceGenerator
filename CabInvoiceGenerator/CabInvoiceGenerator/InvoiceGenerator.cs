using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        RideType objRideType;
        private RideRepository objRideRepository;

        private readonly double MIN_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly double MIN_FARE;

        /// <summary>
        /// Constructor to create Ride Repository Instance
        /// </summary>
        public InvoiceGenerator(RideType objRideType)
        {
            this.objRideType = objRideType;
            this.objRideRepository = new RideRepository();

            try
            {
                if (objRideType.Equals(RideType.PREMIUM))
                {
                    this.MIN_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MIN_FARE = 20;
                }
                else if (objRideType.Equals(RideType.NORMAL))
                {
                    this.MIN_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MIN_FARE = 5;
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
            }
        }

        /// <summary>
        /// Function to Calculate Fare
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                totalFare = distance * MIN_COST_PER_KM + time * COST_PER_TIME;
            }
            catch (CabInvoiceException)
            {
                if (objRideType.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
                }
                if (distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
                }
                if (time < 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
                }
            }
            return Math.Max(totalFare, MIN_FARE);
        }

        /// <summary>
        /// Function to calculate total fare and generating summary for multiple rides
        /// </summary>
        /// <param name="objrides">The objrides.</param>
        /// <returns></returns>
        public InvoiceSummary CalculateFare(Ride[] objrides)
        {
            double totalFare = 0;
            try
            {
                foreach (Ride ride in objrides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
            }
            catch (CabInvoiceException)
            {
                if (objrides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Ride Are Null");
                }
            }
            return new InvoiceSummary(objrides.Length, totalFare);
        }

        /// <summary>
        /// Function to add rides for UserId
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="objrides">The objrides.</param>
        public void AddRides(string userId, Ride[] objrides)
        {
            try
            {
                objRideRepository.AddRide(userId, objrides);
            }
            catch (CabInvoiceException)
            {
                if (objrides!= null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides Are Null");
                }
            }
        }

        /// <summary>
        /// Function to get summary by UserID
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            try
            {
                return this.CalculateFare(objRideRepository.GetRides(userId));
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid User ID");
            }
        }
    }
}
