using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CRUD.DAL.Service;
using WebAPI_CRUD.ViewModel;

namespace WebAPI_CRUD.DAL.Implementation
{
    public class StudentService : IStudent
    {
        private readonly WebAPI_DemoEntities _DemoEntities;
        public StudentService()
        {
            this._DemoEntities = new WebAPI_DemoEntities();
        }
         
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<StudentViewModel> GetStudentDetails()
        {
            List<StudentViewModel> studentmodel = null;
            studentmodel = _DemoEntities.Students.Select(x => new StudentViewModel()
            {
                ID = x.Id,
                Name = x.Name,
                City = x.City,
                Email = x.Email
            }).ToList<StudentViewModel>();
            return studentmodel;
        }

        
    }
}