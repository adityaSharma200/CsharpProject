using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApiProject.Model;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

namespace WebApiProject.Controllers
{
    [Route("api/WebApi")]
    [EnableCors("ApiCorsPolicy")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IConfiguration configuration;

        public ProductController(IConfiguration configuration)
        { 
            this.configuration = configuration;
        
        }

        [HttpGet,Route("GetAllProduct")]
        public ContentResult GetAllProduct()
        { 
            Product p = new Product(configuration);
            List<ProductEntity> proentity = p.getProduct();
            var json = JsonConvert.SerializeObject(proentity);
            
            return Content(json, "application/json");
        
        
        }

        [HttpPost,Route("DeleteRecord")]
        public void DeleteRecord(string id)
        {
            Product p = new Product(configuration);
            p.DeleteRecord(Convert.ToInt16(id));


        }

        [HttpPost, Route("PostProduct")]
        public void PostRecord(dynamic pe)
        {
            string obj = Convert.ToString(pe);

           ProductEntity entity =  JsonConvert.DeserializeObject<ProductEntity>(obj);

            Product p = new Product(configuration);
            
            p.InsertRecord(entity);
            
        }

        [HttpPost,Route("UpdateP")]
        public void UpdateProduct(dynamic pe)
        {
            string obj = Convert.ToString(pe);

            ProductEntity entity = JsonConvert.DeserializeObject<ProductEntity>(obj);

            Product p = new Product(configuration);

            p.UpdateRecord(entity);
        }

    }
}
