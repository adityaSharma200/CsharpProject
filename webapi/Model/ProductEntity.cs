using System.ComponentModel.DataAnnotations;

namespace WebApiProject.Model
{
    public class ProductEntity
    {
        [Required]
        public int Pid { set; get; }

        [Required]
        public string Pname { set; get; }

        [Required]
        public int Price { set; get; }

    }
}
