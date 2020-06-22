using Microsoft.EntityFrameworkCore;
using RestFull_Api.Data;
using RestFull_Api.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestFull_Api.Models.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestFull_ApiContext _context;

        public UnitOfWork(RestFull_ApiContext context, IEmployRepository employ, IStudentRepository student)
        {
            _context = context;
            _employRepository = employ;
            _studentRepository = student;
        }
        public IEmployRepository _employRepository { get; private set; }
        public IStudentRepository _studentRepository { get; private set; }
       
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
