using CarparkBookingApi.Repository.Database;
using CarparkBookingApi.Repository.Interface.DTO;
using CarparkBookingApi.Repository.Interface.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarparkBookingApi.Repository
{
    public class AvailabilityRepository : IAvailabilityRepository
    {
        private readonly IDBContext dbContext;

        public AvailabilityRepository(IDBContext context)
        {
            dbContext = context;
        }
        public async Task<List<BookingItemDto>> GetAvailability(DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            var result = this.dbContext.BookingItemDBSet
                             .Where(x => x.BookingDate.Date >= dateTimeFrom.Date && x.BookingDate.Date <= dateTimeTo.Date && x.IsActive)
                             .Select(b => new BookingItemDto
                             {
                                 BookingId = b.BookingId,
                                 BookingItemId = b.ID,
                                 BookingDay = b.BookingDate
                             }).ToList();
            return result;
        }
    }
}
