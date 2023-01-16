using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CarparkBookingApi.Repository.Interface.DTO
{
    public class CreateBookingDto
    {
        public int CustomerId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<CreateBookingItemDto> CreateBookingItems { get; set; } = new List<CreateBookingItemDto>();
    }

    public class CreateBookingItemDto
    { 
      public DateTime BookingDate { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
