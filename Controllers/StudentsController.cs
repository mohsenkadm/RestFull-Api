using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestFull_Api.Data;
using RestFull_Api.Models.Entity;
using RestFull_Api.Models.IRepository;
using RestFull_Api.Models.Repository;

namespace RestFull_Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StudentsController : MasterController
    {
        
        public StudentsController(IUnitOfWork unitOfWork) :base(unitOfWork)
        {
           
        }

        // GET: api/Students
        //[HttpGet("{RecordName}", Name = "GetStudent")]
        [HttpGet]
        public IEnumerable<Student> GetStudent()
        {

            return _unitOfWork._studentRepository.GetAll();

        }
        // GET: api/StudentsWithGender
        [HttpGet]
        //  [HttpGet("{RecordName}", Name = "GetStudentWithGender")]
        public IEnumerable<Student> GetStudentWithGender()
        {

            return _unitOfWork._studentRepository.GetStudentWithGender();

        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {

            var student = (_unitOfWork._studentRepository.Get(id));
            if (student == null)
            {
                return NotFound();
            }

            return student;

        }

        // PUT: api/Students/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutStudent(int id, Student student)
        {

            _unitOfWork._studentRepository.Put(student);
            _unitOfWork.Complete();
            return NoContent();

        }

        // POST: api/Students
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Student> PostStudent(Student student)
        {

            _unitOfWork._studentRepository.Add(student);
            _unitOfWork.Complete();


            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public ActionResult<Student> DeleteStudent(int id)
        {

            var Student = _unitOfWork._studentRepository.Get(id);
            if (Student == null)
            {
                return NotFound();
            }
            _unitOfWork._studentRepository.Remove(Student);
            _unitOfWork.Complete();
            return Student;

        }


    }
}
