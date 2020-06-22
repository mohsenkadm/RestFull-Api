using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestFull_Api.Data;
using RestFull_Api.Models;
using RestFull_Api.Models.IRepository;
using RestFull_Api.Models.Repository;

namespace RestFull_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmploysController : MasterController
    {

      
        public EmploysController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
           
        }

        // GET: api/employs
        [HttpGet]
        public IEnumerable<Employ> GetEmploy()
        {
            return _unitOfWork._employRepository.GetAll();


            // return await _context.employ.ToListAsync();
        }

        // GET: api/employs/5
        [HttpGet("{id}")]
        public ActionResult<Employ> GetEmploy(int id)
        {
            var employ = (_unitOfWork._employRepository.Get(id));
            if (employ == null)
            {
                return NotFound();
            }

            return employ;

        }

        // PUT: api/employs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutEmploy(Employ employ)
        {
            _unitOfWork._employRepository.Put(employ);
            _unitOfWork.Complete();
            return NoContent();

        }

        // POST: api/employs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Employ> PostEmploy(Employ employ)
        {

            _unitOfWork._employRepository.Add(employ);
            _unitOfWork.Complete();

            return CreatedAtAction("Getemploy", new { id = employ.Id }, employ);
        }

        // DELETE: api/employs/5
        [HttpDelete("{id}")]
        public ActionResult<Employ> DeleteEmploy(int id)
        {

            var employ = _unitOfWork._employRepository.Get(id);
            if (employ == null)
            {
                return NotFound();
            }
            _unitOfWork._employRepository.Remove(employ);
            _unitOfWork.Complete();
            return employ;



        }

    }
}
