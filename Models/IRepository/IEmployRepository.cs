using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestFull_Api.Models.IRepository
{
    public interface IEmployRepository : IRepository<Employ>
    {
        IEnumerable<Employ> GetEmploy(int id);
    }
}
