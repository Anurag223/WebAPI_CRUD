using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_CRUD.ViewModel;

namespace WebAPI_CRUD.Controllers
{
    public class StudentController : ApiController
    {
        //GET - Retrieve details of all students
        private readonly WebAPI_DemoEntities _DemoEntities;
        public StudentController()
        {
            _DemoEntities = new WebAPI_DemoEntities();
        }
        [HttpGet]
        [ActionName("GetStudentDetails")]
        public IHttpActionResult GetStudentDetails()
        {
            IList<StudentViewModel> studentmodel = null;
            studentmodel = _DemoEntities.Students.Select(x => new StudentViewModel()
            {
                ID = x.Id,
                name = x.Name,
                city = x.City,
                email = x.Email
            }).ToList<StudentViewModel>();

            return studentmodel.Count > 0 ? StatusCode(HttpStatusCode.OK) : StatusCode(HttpStatusCode.NotFound);
        }

        [HttpPost]
        [ActionName("CreateStudent")]
        public IHttpActionResult CreateStudent(StudentViewModel studentViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid request please check again");

            var studentdata = _DemoEntities.Students.Add(new Student()
            {
                Id = studentViewModel.ID,
                Name = studentViewModel.name,
                Email = studentViewModel.city,
                City = studentViewModel.city
            });

            _DemoEntities.SaveChanges();
            return Ok(studentdata);
        }
    }
}
