using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarparkBookingApi.Repository.Interface.DatabaseEntities
{
    public class CustomerAddress
    {
        public int ID { get; set; }
        public string AddressLine { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public int CustomerId { get; set; }
    }
}
