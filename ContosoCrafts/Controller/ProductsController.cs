namespace ContosoCrafts.Controller
{
    using ContosoCrafts.Models;
    using ContosoCrafts.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        //[HttpPatch] "{FromBody}"
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery] string productId, [FromQuery] int rating)
        {
            ProductService.AddRating(productId, rating);
            return Ok();
        }

    }
}
