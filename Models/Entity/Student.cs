using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestFull_Api.Models.Entity
{
    public class Student
    {
        public Student()
        {
            //Genders = new HashSet<Gender>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Stage { get; set; }
        public  int? Gander_Id { get; set; }
        public Gender Gender { get; set; }
        public string School { get; set; }
       
    }
}
