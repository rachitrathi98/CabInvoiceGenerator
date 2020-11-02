using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> userRides;

        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        public void AddRide(string userId, Ride[] ride)
        {
            bool ride_is_present = this.userRides.ContainsKey(userId);
            try
            {
                if (!ride_is_present)
                {
                    List<Ride> new_ride = new List<Ride>();
                    new_ride.AddRange(ride);
                    this.userRides.Add(userId, new_ride);
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides Are Null");
            }
        }

        public Ride[] GetRide(string userId)
        {
            try
            {
                return this.userRides[userId].ToArray();
            }
            catch (Exception)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid User ID");
            }
        }
    }
}
