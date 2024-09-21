using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudOperationEmployee.Models
{
    public class EmployeeModel
    {
        [Required]
        public int id { set; get; }

        [Required]
        public string name { set; get; }
        [Required]
        public string email { set; get; }
        [Required]
        public string phone { set; get; }
        [Required]
        public string city { set; get; }
        [Required]
        public string gender { set; get; }

    }
}