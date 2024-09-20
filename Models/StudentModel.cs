using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudFirstAditya.Models
{
    public class StudentModel
    {
        [Display(Name ="Id")]
        public int id { get; set; }


        [Required(ErrorMessage ="name is required.")]
       public  string name {get; set;}

        [Required(ErrorMessage = "age is required")]
        public int age { get; set;}

        [Required(ErrorMessage ="City is required")]
        public string City { get; set;}

    }
}