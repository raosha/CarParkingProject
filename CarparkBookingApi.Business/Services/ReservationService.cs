using CarparkBookingApi.Business.Interface.DTO.Request;
using CarparkBookingApi.Business.Interface.DTO.Response;
using CarparkBookingApi.Business.Interface.Factories;
using CarparkBookingApi.Business.Interface.Interface;
using CarparkBookingApi.Repository.Interface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarparkBookingApi.Business.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository reservationRepository;
        private readonly IAvailabilityService availabilityService;
        private readonly ICarParkObjectFactory carParkObjectFactory;
        private readonly ICustomerRepository customerRepository;

        public ReservationService(IReservationRepository reservationRepository, 
             IAvailabilityService availabilityService, 
             ICarParkObjectFactory carParkObjectFactory,
             ICustomerRepository customerRepository)
        {
            this.reservationRepository = reservationRepository;
            this.availabilityService = availabilityService;
            this.carParkObjectFactory = carParkObjectFactory;
            this.customerRepository = customerRepository;
        }

        public async Task<BookingCancellationResponseDto> CancelBooking(int bookingId)
        {
            var result = await reservationRepository.CancelReservation(bookingId);
            return carParkObjectFactory.GetBookingCancellationResponseDto(result);
        }

        public async Task<BookingResponseDto> CreateBooking(BookingRequest bookingRequest)
        {
           
            if (!await availabilityService.OkToBook(bookingRequest.DateFrom, bookingRequest.DateTo))
            {
                //Can not do booking as there may be a selected day or days where they are no available spaces
                return this.carParkObjectFactory.GetBookingResponseDto(false, "Sorry booking cannot be done due to unavailable spaces!");
            }
            else
            {
                //usually this will be done via a unit of work as one business transaction but due lack of time this approach has been adapted.
                var customerId = bookingRequest.Customer.CustomerId;
                if (customerId == 0)
                {
                    customerId = await this.customerRepository.AddCustomerDetails(this.carParkObjectFactory.GetCustomerDetailsDto(bookingRequest));
                }

                await this.reservationRepository.CreateBooking(this.carParkObjectFactory.GetBookingDto(bookingRequest, customerId));

                return this.carParkObjectFactory.GetBookingResponseDto(true, "Booking Completed!");
            }
        }
    }
}
