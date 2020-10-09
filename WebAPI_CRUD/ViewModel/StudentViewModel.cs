using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_CRUD.ViewModel
{
    public class StudentViewModel
    {
        public int ID { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string city { get; set; }
    }
}