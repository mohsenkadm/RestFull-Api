using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestFull_Api.Data;
using RestFull_Api.Models.Entity;
using RestFull_Api.Models.Repository;

namespace RestFull_Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly RestFull_ApiContext _context;

        public StudentsController(RestFull_ApiContext context)
        {
            _context = context;
        }

        // GET: api/Students
        //[HttpGet("{RecordName}", Name = "GetStudent")]
        [HttpGet]
        public IEnumerable<Student> GetStudent()
        {
            using (var unitOfWork = new UnitOfWork(_context))
            {
                return unitOfWork.student.GetAll();
            }
        }
        // GET: api/StudentsWithGender
        [HttpGet]
      //  [HttpGet("{RecordName}", Name = "GetStudentWithGender")]
        public IEnumerable<Student> GetStudentWithGender()
        {
            using (var unitOfWork = new UnitOfWork(_context))
            {
                return unitOfWork.student.GetStudentWithGender();
            }
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            using (var unitOfWork = new UnitOfWork(_context))
            {
                var student = (unitOfWork.student.Get(id));
                if (student == null)
                {
                    return NotFound();
                }

                return student;
            }
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutStudent(int id, Student student)
        {
            using (var unitOfWork = new UnitOfWork(_context))
            {
                unitOfWork.student.Put(student);
                unitOfWork.Complete();
                return NoContent();
            }
        }

        // POST: api/Students
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Student> PostStudent(Student student)
        {
            using (var unitOfWork = new UnitOfWork(_context))
            {
                unitOfWork.student.Add(student);
                unitOfWork.Complete();
            }
          
            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public ActionResult<Student> DeleteStudent(int id)
        {
            using (var unitOfWork = new UnitOfWork(_context))
            {
                var Student = unitOfWork.student.Get(id);
                if (Student == null)
                {
                    return NotFound();
                }
                unitOfWork.student.Remove(Student);
                unitOfWork.Complete();
                return Student;
            }
        }

       
    }
}
