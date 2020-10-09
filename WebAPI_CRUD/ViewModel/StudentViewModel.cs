using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI_CRUD.ViewModel
{
    public class StudentViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string City { get; set; }
    }
}