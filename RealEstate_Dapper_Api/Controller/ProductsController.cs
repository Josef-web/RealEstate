using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Repositories.ProductRepositories;

namespace RealEstate_Dapper_Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
   private readonly IProductRepository _productRepository;
   
   public ProductsController(IProductRepository productRepository)
   {
      _productRepository = productRepository;
   }

   [HttpGet]
   public async Task<IActionResult> ProductList()
   {
      var values = await _productRepository.GetAllProduct();
      return Ok(values);
   }
   [HttpGet("ProductListWithCategory")]
   public async Task<IActionResult> ProductListWithCategory()
   {
      var values = await _productRepository.GetAllProductWithCategoryAsync();
      return Ok(values);
   }

   [HttpGet("ProductDealOfTheDayStatusChangeToTrue/{id}")]
   public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
   {
      _productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
      return Ok("İlan Günün Fırsatları Arasına Eklendi.");
   }
   
   [HttpGet("ProductDealOfTheDayStatusChangeToFalse/{id}")]
   public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
   {
      _productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
      return Ok("İlan Günün Fırsatlarından Kaldırıldı.");
   }
   
   [HttpGet("LastFiveProductList")]
   public async Task<IActionResult> LastFiveProductList()
   {
      var values = await _productRepository.GetLastFiveProduct();
      return Ok(values);
   }

   [HttpGet("ProductAdvertsListByEmployeeIdByTrue")]
   public async Task<IActionResult> ProductAdvertsListByEmployeeIdByTrue(int id)
   {
      var values = await _productRepository.GetProductAdvertListByEmployeeAsyncByTrue(id);
      return Ok(values);
   }
   
   [HttpGet("ProductAdvertsListByEmployeeIdByFalse")]
   public async Task<IActionResult> ProductAdvertsListByEmployeeIdByFalse(int id)
   {
      var values = await _productRepository.GetProductAdvertListByEmployeeAsyncByFalse(id);
      return Ok(values);
   }

   [HttpPost("CreateProduct")]
   public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
   {
      await _productRepository.CreateProduct(createProductDto);
      return Ok("Advert created successfully");
   }

   [HttpGet("GetProductById")]
   public async Task<IActionResult> GetProductById(int id)
   {
      var values = await _productRepository.GetProductById(id);
      return Ok(values);
   }

   [HttpGet("ResultPropertyWithSearchList")]
   public async Task<IActionResult> ResultPropertyWithSearchList(string keyword, int propertyCategoryId, string city)
   {
      var values = await _productRepository.ResultPropertyWithSearchList(keyword, propertyCategoryId, city);
      return Ok(values);
   }

   [HttpGet("GetPropertyByDealOfTheDayTrueWithCategoryAsync")]
   public async Task<IActionResult> GetPropertyByDealOfTheDayTrueWithCategoryAsync()
   {
      var values = await _productRepository.GetPropertyByDealOfTheDayTrueWithCategory();
      return Ok(values);
   }
   
   [HttpGet("LastThreeProductList")]
   public async Task<IActionResult> LastThreeProductList()
   {
      var values = await _productRepository.GetLastThreeProduct();
      return Ok(values);
   }
   
   
}