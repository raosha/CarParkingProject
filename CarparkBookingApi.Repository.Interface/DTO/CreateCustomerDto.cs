using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarparkBookingApi.Repository.Interface.DTO
{
    public class CreateCustomerDto
    {
       
            public int CustomerId { get; set; }
           
            public string FirstName { get; set; }
           
            public string LastName { get; set; }
          
            public CustomerAddress CustomerAddress { get; set; }
       
    }

    public class CustomerAddress
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string PostCode { get; set; }
       
        public string City { get; set; }
    }
}
