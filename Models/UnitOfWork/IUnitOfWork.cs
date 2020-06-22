
using Microsoft.EntityFrameworkCore;
using RestFull_Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestFull_Api.Models.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        public IEmployRepository _employRepository { get; }
        public IStudentRepository _studentRepository { get;  }
        int Complete();
        
    }
}
