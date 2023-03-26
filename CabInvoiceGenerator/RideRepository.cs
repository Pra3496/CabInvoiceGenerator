using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<int, List<Ride>> userRides = null;

        public RideRepository()
        {
            this.userRides = new Dictionary<int, List<Ride>>();
        }

        public void AddRide(int userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDE, "Ride are Null");
            }
        }

        public Ride[] GetRides(int userId)
        {
            try
            {
                return this.userRides[userId].ToArray();
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid User Id");
            }
        }

        public void Display()
        {
            foreach(var item in this.userRides)
            {
                Console.WriteLine("\n\tUser Id is : "+item.Key);
                foreach(Ride ride in item.Value)
                {
                    Console.WriteLine("Ride Time : "+ride.time);
                    Console.WriteLine("Ride Distance : "+ride.distance);
                }
            }
        }
    }
}
