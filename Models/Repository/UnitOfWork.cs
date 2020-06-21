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
        public UnitOfWork(RestFull_ApiContext context)
        {
            _context = context;
            Employ = new EmployRepository(_context);
            student = new StudentRepository(_context);
        }

        public IEmployRepository Employ { get; private set; }
        public IStudentRepository student { get; private set; }
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
