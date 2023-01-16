using CarparkBookingApi.Repository.Interface.DTO;
using CarparkBookingApi.Repository.Interface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarparkBookingApi.Repository
{
    public class ParkingSlotRepository : IParkingSlotRepository
    {
        private readonly IDBContext dBContext;

        public ParkingSlotRepository(IDBContext context)
        {
            this.dBContext= context;
        }
        public async Task<ParkingSlotDto> GetParkingSlotsTotal()
        {
            var result =  new ParkingSlotDto { TotalParkingSlots =  this.dBContext.ParkingSlotDBSet.Count() };
            return await Task.FromResult(result);
        }
    }
}
