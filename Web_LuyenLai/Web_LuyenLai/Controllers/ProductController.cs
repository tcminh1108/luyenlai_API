using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_LuyenLai.Model;

namespace Web_LuyenLai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> ListProduct = new List<Product>();
        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(ListProduct);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var product = ListProduct.SingleOrDefault(p => p.Id == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductModel productModel)
        {
            try
            {
                var product = new Product{
                    Id = Guid.NewGuid(), 
                    Name = productModel.Name,
                    Price = productModel.Price
                };
                ListProduct.Add(product);
                return Ok(new {Success = true, Data = product});
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(string id, ProductModel productModel)
        {
            try
            {
                var product = ListProduct.SingleOrDefault(p => p.Id == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                product.Name = productModel.Name;
                product.Price = productModel.Price;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var product = ListProduct.SingleOrDefault(p => p.Id == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                ListProduct.Remove(product);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
