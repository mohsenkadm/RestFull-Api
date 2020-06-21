using RestFull_Api.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestFull_Api.Models.IRepository
{
    public interface IStudentRepository:IRepository<Student> 
    {
        IEnumerable<Student> GetStudentWithGender();
    }
}
