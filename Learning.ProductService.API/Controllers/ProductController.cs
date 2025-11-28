using Microsoft.AspNetCore.Mvc;

namespace Learning.ProductService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new List<string> { "Iphone 17", "Samsung Galaxy"});
        }
    }
}
