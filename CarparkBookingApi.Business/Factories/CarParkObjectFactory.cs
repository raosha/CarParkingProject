using CarparkBookingApi.Business.Interface.DTO.Request;
using CarparkBookingApi.Business.Interface.DTO.Response;
using CarparkBookingApi.Business.Interface.Factories;
using CarparkBookingApi.Repository.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarparkBookingApi.Business.Factories
{
    public class CarParkObjectFactory : ICarParkObjectFactory
    {
        public BookingCancellationResponseDto GetBookingCancellationResponseDto(bool result)
        {
            return new BookingCancellationResponseDto
            {
                IsCancelled = result,
                Message = result ? "Booking Cancelled Successfully" : "Cancellation Unsuccessfully"
            };
        }

        public CreateBookingDto GetBookingDto(BookingRequest bookingRequest, int customerID)
        {
            var createBookingItems = new List<CreateBookingItemDto>();
            var dateFrom = bookingRequest.DateFrom;
            while (dateFrom.Date <= bookingRequest.DateTo.Date)
            {
                createBookingItems.Add(new CreateBookingItemDto 
                {
                  BookingDate = dateFrom
                });
                dateFrom = dateFrom.AddDays(1);
            }

            return new CreateBookingDto
            {
                DateFrom = bookingRequest.DateFrom,
                DateTo= bookingRequest.DateTo,
                CreateBookingItems = createBookingItems,
                CustomerId= customerID
            };

        }

        public BookingResponseDto GetBookingResponseDto(bool isBooked, string message)
        {
            return new BookingResponseDto
            {
                IsBooked = isBooked,
                Message = message, 
            };
        }

        public CreateCustomerDto GetCustomerDetailsDto(BookingRequest bookingRequest)
        {
            return new CreateCustomerDto
            {
                FirstName = bookingRequest.Customer.FirstName,
                LastName = bookingRequest.Customer.LastName,
                CustomerAddress = new Repository.Interface.DTO.CustomerAddress 
                {
                  AddressLine1 = bookingRequest.Customer.CustomerAddress.AddressLine1,
                  City = bookingRequest.Customer.CustomerAddress.City,
                  PostCode = bookingRequest.Customer.CustomerAddress.PostCode
                }
            };
        }


    }
}
