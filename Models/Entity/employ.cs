using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestFull_Api.Models
{
    public class employ
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Gender { get; set; }

      [Required]
        public int Salary { get; set; }
    }
}
