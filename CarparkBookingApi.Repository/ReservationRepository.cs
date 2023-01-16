using CarparkBookingApi.Repository.Interface.DTO;
using CarparkBookingApi.Repository.Interface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitites = CarparkBookingApi.Repository.Interface.DatabaseEntities;

namespace CarparkBookingApi.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly IDBContext dbContext;

        public ReservationRepository(IDBContext context)
        {
            dbContext = context;
        }
        public async Task<bool> CancelReservation(int bookingId)
        {
            var result = false;
            foreach (var bookingItem in this.dbContext.BookingItemDBSet.Where(x => x.BookingId == bookingId))
            { 
              bookingItem.IsActive= false;
              result = true;
            }

            return await Task.FromResult(result);
        }

        public async Task CreateBooking(CreateBookingDto createBookingDto)
        {
            var maxBookingId = this.dbContext.BookingsDBSet.Max(x => x.BookingId) +1;
            //Normally I will use Adapter Pattern to return this parameters when using ADO.net Or object when using ORM tool
            this.dbContext.BookingsDBSet.Add(new Entitites.Booking
            {
                BookingId  = maxBookingId, // typically this will identity field in database so you wouldn't have to do this
                CustomerId = createBookingDto.CustomerId,
                DateFrom = createBookingDto.DateFrom,
                DateTo= createBookingDto.DateTo,
            });


            var maxBookingItemId = this.dbContext.BookingItemDBSet.Max(x => x.ID) +1;
            foreach (var item in createBookingDto.CreateBookingItems)
            {
                this.dbContext.BookingItemDBSet.Add(new Entitites.BookingItem
                {
                  BookingDate = item.BookingDate,
                  ID = maxBookingItemId,
                  BookingId = maxBookingId,
                  IsActive = true
                });
                maxBookingItemId = maxBookingItemId + 1;
            }
            
        }
    }
}
