using CarparkBookingApi.Repository.Interface.DTO;
using CarparkBookingApi.Repository.Interface.Interface;
using Entitites = CarparkBookingApi.Repository.Interface.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarparkBookingApi.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDBContext dBContext;

        public CustomerRepository(IDBContext context)
        {
            this.dBContext= context;
        }

        public async Task<int> AddCustomerDetails(CreateCustomerDto customerDetails)
        {
            var maxCustomerID = this.dBContext.CustomerDBSet.Max(x => x.CustomerID) + 1;
            //Normally I will use Adapter Pattern to return this parameters when using ADO.net Or object when using ORM tool
            this.dBContext.CustomerDBSet.Add(new Entitites.Customer 
            {
               CustomerID = maxCustomerID, // typically this will identity field in database so you wouldn't have to do this
               FirstName= customerDetails.FirstName ,
               LastName= customerDetails.LastName ,
            });

            var maxAddressId = this.dBContext.CustomerAddressDBSet.Max(x => x.ID) + 1;
            this.dBContext.CustomerAddressDBSet.Add(new Entitites.CustomerAddress 
            {
              ID= maxAddressId,// typically this will identity field in database so you wouldn't have to do this
              AddressLine = customerDetails.CustomerAddress.AddressLine1,
              City= customerDetails.CustomerAddress.City,
              CustomerId = maxCustomerID,
              PostCode = customerDetails.CustomerAddress.PostCode,
            });
           return maxCustomerID;
        }
    }
}
