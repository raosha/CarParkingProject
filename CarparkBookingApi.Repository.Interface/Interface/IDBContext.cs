using CarparkBookingApi.Repository.Interface.DatabaseEnitities;
using CarparkBookingApi.Repository.Interface.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarparkBookingApi.Repository.Interface.Interface
{
    public interface IDBContext
    {
        public List<Booking> BookingsDBSet { get; }
        public List<BookingItem> BookingItemDBSet { get; }
        public List<Customer> CustomerDBSet { get; }
        public List<CustomerAddress> CustomerAddressDBSet { get; }

        public List<ParkingSlot> ParkingSlotDBSet { get; }
    }
}
