using Microsoft.EntityFrameworkCore;
using RestFull_Api.Data;
using RestFull_Api.Models.Entity;
using RestFull_Api.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestFull_Api.Models.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(DbContext context) : base(context)
        {

        }

        public RestFull_ApiContext PlutoContext
        {
            get { return Context as RestFull_ApiContext; }
        }

        public IEnumerable<Student> GetStudentWithGender()
        {
            return PlutoContext.Student.Include(x => x.Gender).ToList();
        }
    }
}
