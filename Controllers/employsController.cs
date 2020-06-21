using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestFull_Api.Data;
using RestFull_Api.Models;
using RestFull_Api.Models.Repository;

namespace RestFull_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class employsController : ControllerBase
    {
        private readonly RestFull_ApiContext _context;
        public employsController(RestFull_ApiContext context)
        {
            _context = context;
        }

        // GET: api/employs
        [HttpGet]
        public IEnumerable<employ> Getemploy()
        {
            using (var unitOfWork = new UnitOfWork(_context))
            {
                return unitOfWork.Employ.GetAll();
            }
            
            // return await _context.employ.ToListAsync();
        }

        // GET: api/employs/5
        [HttpGet("{id}")]
        public ActionResult<employ> Getemploy(int id)
        {
            using (var unitOfWork = new UnitOfWork(_context))
            {
                var employ=(unitOfWork.Employ.Get(id));
                if (employ == null)
                {
                    return NotFound();
                }

                return employ;
            }
        }

        // PUT: api/employs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult Putemploy( employ employ)
        {
            using (var unitOfWork = new UnitOfWork(_context))
            {
                unitOfWork.Employ.Put(employ);
                unitOfWork.Complete();
            return NoContent();
            }
        }

        // POST: api/employs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<employ> Postemploy(employ employ)
        {
            using (var unitOfWork = new UnitOfWork(_context))
            {
                unitOfWork.Employ.Add(employ);
                unitOfWork.Complete();
            }
            return CreatedAtAction("Getemploy", new { id = employ.Id }, employ);
        }

        // DELETE: api/employs/5
        [HttpDelete("{id}")]
        public ActionResult<employ> Deleteemploy(int id)
        {
           
            using (var unitOfWork = new UnitOfWork(_context))
            {
                var employ =  unitOfWork.Employ.Get(id);
                if (employ == null)
                {
                    return NotFound();
                }
                unitOfWork.Employ.Remove(employ);
                unitOfWork.Complete(); 
                return employ;
            }

          
        }

    }
}
