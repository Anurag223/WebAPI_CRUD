using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using WebAPI_CRUD.DAL;
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
                Name = x.Name,
                City = x.City,
                Email = x.Email
            }).ToList<StudentViewModel>();

            if (studentmodel.Count <= 0)
                return NotFound();
            else return Ok(studentmodel);
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
                Name = studentViewModel.Name,
                Email = studentViewModel.Email,
                City = studentViewModel.City
            });

            _DemoEntities.SaveChanges();
            return Ok(studentdata);
        }

        [HttpPut]
        [ActionName("UpdateStudentDetails")]
        public IHttpActionResult UpdateStudentDetails(StudentViewModel studentViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please enter correct details and check the url");
            {
                var studentmodeldata = _DemoEntities.Students.FirstOrDefault(m=>m.Id==studentViewModel.ID);
                if (studentViewModel != null)
                {
                    studentmodeldata.Name = studentViewModel.Name;
                    studentmodeldata.Email = studentViewModel.Email;
                    studentmodeldata.City = studentViewModel.City;

                    _DemoEntities.SaveChanges();
                }
                else
                    return NotFound();
            }
            return Ok();
        }

        [HttpDelete]
        [ActionName("DeleteCustomer")]
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (id <= 0) 
                return BadRequest("Please enter valid customer id");

            using(var customerEntity= new WebAPI_DemoEntities())
            {
                var customer = customerEntity.Students.Where(x => x.Id == id).FirstOrDefault();
                customerEntity.Entry(customer).State = System.Data.Entity.EntityState.Deleted;
            }

            return Ok();
        }

        [HttpGet]
        [ActionName("SearchByProductID")]
        public IHttpActionResult SearchByProductID(int id)
        {
            if (id <= 0)
                return BadRequest("Please enter valid customer id");

            using(var studententity= new WebAPI_DemoEntities())
            {
                var studentdata = studententity.Students.Where(x => x.Id == id).FirstOrDefault();
                return Ok(studententity);
            }

        }

    }
}
