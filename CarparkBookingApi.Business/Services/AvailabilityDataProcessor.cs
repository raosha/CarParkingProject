using CarparkBookingApi.Business.Interface.DTO.Request;
using CarparkBookingApi.Business.Interface.DTO.Response;
using CarparkBookingApi.Business.Interface.Interface;
using CarparkBookingApi.Repository.Interface.DTO;
using CarparkBookingApi.Repository.Interface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarparkBookingApi.Business.Services
{
    public class AvailabilityDataProcessor : IAvailabilityDataProcessor
    {
        private readonly IParkingSlotRepository parkingSlotRepository;
        private const string ALL_FREE_SPACES = "all free spaces";
        private const string NO_FREE_SPACES = "no free spaces";
        private const string FREE_SPACES = "free spaces";

        public AvailabilityDataProcessor(IParkingSlotRepository parkingSlotRepository)
        {
            this.parkingSlotRepository = parkingSlotRepository;
        }
        public async Task<IEnumerable<AvailabilityDto>> GetResponseResult(List<BookingItemDto> bookingItems, AvailabilityRequest request)
        {
            List<AvailabilityDto> result;
            if (bookingItems.Count == 0)
            {
                result = await GetResultIfNoBookingFound(request);
            }
            else
            {
                result = await GetResultWithBooking(bookingItems, request);
            }
            return result;
        }

        private async Task<List<AvailabilityDto>> GetResultWithBooking(List<BookingItemDto> bookingItems, AvailabilityRequest request)
        {
            List<AvailabilityDto> result = new List<AvailabilityDto>();
            var availableSpaces = await parkingSlotRepository.GetParkingSlotsTotal();
            while (request.DateFrom.Date <= request.DateTo.Date)
            {
                var totalSpacesTaken = bookingItems.Where(x => x.BookingDay.Date == request.DateFrom.Date).ToList().Count;
                result.Add(new AvailabilityDto
                {
                    AvailabilityDetails = $"{request.DateFrom.ToString("dd/MM/yyyy")} - {GetFreeSpaceDescription(totalSpacesTaken, availableSpaces)}"
                });
                request.DateFrom = request.DateFrom.AddDays(1);
            }
            return result;
        }



        private async Task<List<AvailabilityDto>> GetResultIfNoBookingFound(AvailabilityRequest request)
        {
            List<AvailabilityDto> result = new List<AvailabilityDto>();
            while (request.DateFrom <= request.DateTo)
            {
                result.Add(new AvailabilityDto
                {
                    AvailabilityDetails = $"{request.DateFrom.ToString("dd/MM/yyyy")} - {ALL_FREE_SPACES}"
                });
                request.DateFrom = request.DateFrom.AddDays(1);
            }
            return result;
        }

        private string GetFreeSpaceDescription(int totalSpacesTaken, ParkingSlotDto slot)
        {
            return totalSpacesTaken == slot.TotalParkingSlots ? NO_FREE_SPACES :
                   totalSpacesTaken == 0 ? ALL_FREE_SPACES : $"{slot.TotalParkingSlots - totalSpacesTaken} {FREE_SPACES}";
        }
    }
}
