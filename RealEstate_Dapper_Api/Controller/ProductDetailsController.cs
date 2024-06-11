using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepositories;

namespace RealEstate_Dapper_Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class ProductDetailsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductDetailsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet("GetProductDetailById")]
    public async Task<IActionResult> GetProductDetailById(int id)
    {
        var values = await _productRepository.GetProductDetailById(id);
        return Ok(values);
    }
}