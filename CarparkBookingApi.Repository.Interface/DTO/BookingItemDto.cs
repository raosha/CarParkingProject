using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarparkBookingApi.Repository.Interface.DTO
{
    public class BookingItemDto
    {
        public int BookingItemId { get; set; }
        public int BookingId { get; set; }
        public DateTime BookingDay { get; set; }
    }
}
