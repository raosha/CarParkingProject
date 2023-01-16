using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarparkBookingApi.Repository.Interface.DatabaseEntities
{
    public class BookingItem
    {
        public int ID { get; set; }
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public bool IsActive { get; set; }
    }
}
