using CarparkBookingApi.Repository.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarparkBookingApi.Repository.Interface.Interface
{
    public interface IAvailabilityRepository
    {
        Task<List<BookingItemDto>> GetAvailability(DateTime dateTimeFrom, DateTime dateTimeTo);
    }
}
