using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarparkBookingApi.Business.Interface.DTO.Request
{
    public class BookingRequest
    {
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        [Required]
        public Customer Customer { get; set; }
    }

    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public CustomerAddress CustomerAddress { get; set; }
    }

    public class CustomerAddress 
    {
        public int Id { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string PostCode { get; set; }
        [Required]
        public string City { get; set; }
    }
}
