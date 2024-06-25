using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductImageRepositories;

namespace RealEstate_Dapper_Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class ProductImagesController : ControllerBase
{
    private readonly IProductImageRepository _productImageRepository;

    public ProductImagesController(IProductImageRepository productImageRepository)
    {
        _productImageRepository = productImageRepository;
    }

    [HttpGet]
    public async Task<IActionResult> ProductImageByProductId(int id)
    {
        var values = await _productImageRepository.GetProductDetailById(id);
        return Ok(values);
    }
}