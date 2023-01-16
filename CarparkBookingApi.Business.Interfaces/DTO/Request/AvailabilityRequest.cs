using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarparkBookingApi.Business.Interface.DTO.Request
{
    public class AvailabilityRequest : IValidatableObject
    {
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            DateTime now = DateTime.Now.Date;
            if (this.DateFrom.Date < now || this.DateTo.Date < now)
            {
                yield return new ValidationResult("Date From or Date To is in the past");
            }
            else if (this.DateTo < this.DateFrom) 
            {
                yield return new ValidationResult("Date To is less than Date From");
            }
        }
    }
}
