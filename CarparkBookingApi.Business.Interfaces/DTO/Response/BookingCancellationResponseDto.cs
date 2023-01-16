using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarparkBookingApi.Business.Interface.DTO.Response
{
    public class BookingCancellationResponseDto
    {
        public bool IsCancelled { get; set; }

        public string Message { get; set; }
    }
}
