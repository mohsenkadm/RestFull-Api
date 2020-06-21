using Microsoft.EntityFrameworkCore;
using RestFull_Api.Data;
using RestFull_Api.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestFull_Api.Models.Repository
{
    public class EmployRepository : Repository<employ>, IEmployRepository
    {
        public EmployRepository(DbContext context) : base(context)
        {

        }

        public RestFull_ApiContext PlutoContext
        {
            get { return Context as RestFull_ApiContext; }
        }

        public IEnumerable<employ> GetEmploy(int id)
        {
            
                return PlutoContext.employ.ToList();
            
        }
    }
}
