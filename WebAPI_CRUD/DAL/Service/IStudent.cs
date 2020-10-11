using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_CRUD.ViewModel;

namespace WebAPI_CRUD.DAL.Service
{
    public interface IStudent :IDisposable
    {
        List<StudentViewModel> GetStudentDetails();

        //void AddStudentDetails(StudentViewModel student);
    }
}
