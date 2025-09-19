using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ProductWebAPI.Exceptions;
using ProductWebAPI.Models;
using ProductWebAPI.Results;

namespace ProductWebAPI.Controllers
{
    [ApiVersion("1", Deprecated = true)]
    [ApiVersion("2")]
    [ApiController]
    [Route("api/v{v:apiVersion}/products")]
    public class ProductController : ControllerBase
    {
        [MapToApiVersion(1)]
        [HttpGet("{productId}")]
        public IActionResult ProductsV1(int productId)
        {

            if(!FakeRepos.FakeRepos.Products.Any(i => i.Id == productId))
            {
                throw new NotFoundException($"Product with id {productId} not found");
            }

            return Ok(new { Data = FakeRepos.FakeRepos.Products.FirstOrDefault(i=>i.Id==productId) });
        }

        [MapToApiVersion(2)]
        [HttpGet("{productId}")]
        public IActionResult ProductsV2(int productId)
        {
            if (!FakeRepos.FakeRepos.Products.Any(i => i.Id == productId))
            {
                return NotFound(Result<Product>.Failure($"Product with id {productId} not found"));
            }

            return Ok(Result<Product>.Success(FakeRepos.FakeRepos.Products.FirstOrDefault(i => i.Id == productId)));
        }

    }
}
