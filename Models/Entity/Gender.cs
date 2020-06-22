using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestFull_Api.Models.Entity
{
    public class Gender
    {
        public Gender()
        {
            //student = new HashSet<Student>();
        }

        [Key]
        public int Gender_Id { get; set; }
        [Required]
        public string Gender_ { get; set; }
       // [ForeignKey("Gender")]
        public Student students { get; set; }
    }
}
