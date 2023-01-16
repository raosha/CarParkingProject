using CarparkBookingApi.Business.Interface.DTO.Request;
using CarparkBookingApi.Business.Interface.DTO.Response;
using CarparkBookingApi.Business.Interface.Interface;
using CarparkBookingApi.Repository.Interface.DatabaseEntities;
using CarparkBookingApi.Repository.Interface.DTO;
using CarparkBookingApi.Repository.Interface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarparkBookingApi.Business.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly IAvailabilityRepository availabilityRepository;
        private readonly IAvailabilityDataProcessor availabilityDataProcessor;
        private readonly IParkingSlotRepository parkingSlotRepository;

        public AvailabilityService(IAvailabilityRepository availabilityRepo, IAvailabilityDataProcessor availabilityDataProcessor, IParkingSlotRepository parkingSlotRepository)
        {
            availabilityRepository = availabilityRepo;
            this.availabilityDataProcessor = availabilityDataProcessor;
            this.parkingSlotRepository = parkingSlotRepository;
        }

        public async Task<IEnumerable<AvailabilityDto>> GetAvailability(AvailabilityRequest request)
        {
            if (request == null || request.DateFrom == DateTime.MinValue || request.DateTo == DateTime.MinValue)
                throw new ArgumentNullException($"{nameof(GetAvailability)}: Throw exception with invalid arguments");

            var currentReservations = await availabilityRepository.GetAvailability(request.DateFrom, request.DateTo);
            return await availabilityDataProcessor.GetResponseResult(currentReservations, request);
        }

        public async Task<bool> OkToBook(DateTime dateFrom, DateTime dateTo)
        {
            if (dateFrom == DateTime.MinValue || dateTo == DateTime.MinValue)
                throw new ArgumentNullException($"{nameof(OkToBook)}: Throw exception with invalid arguments");

            var currentReservations = await availabilityRepository.GetAvailability(dateFrom, dateTo);
            if (currentReservations.Count == 0)
                return true;
            else
            {
                return await CheckIfSpacesAvailableForDateRange(currentReservations, dateFrom, dateTo);
            }
        }

        private async Task<bool> CheckIfSpacesAvailableForDateRange(List<BookingItemDto> currentReservations, DateTime dateFrom, DateTime dateTo)
        {
            var availabilityResult = true;
            var totalSpaces = await parkingSlotRepository.GetParkingSlotsTotal();
            while (dateFrom.Date <= dateTo.Date)
            {
                var dayAvailableSpaces = currentReservations.Where(x => x.BookingDay.Date == dateFrom.Date).ToList().Count;
                if (dayAvailableSpaces == totalSpaces.TotalParkingSlots)
                {
                    availabilityResult = false;
                    break;
                }
                dateFrom = dateFrom.AddDays(1);
            }
            return availabilityResult;
        }
    }
}
