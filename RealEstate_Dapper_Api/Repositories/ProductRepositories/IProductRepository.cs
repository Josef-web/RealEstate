using RealEstate_Dapper_Api.Dtos.ProductDetailDto;
using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepositories;

public interface IProductRepository
{
    Task<List<ResultProductDto>> GetAllProduct();
    Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByTrue(int id);
    Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByFalse(int id);
    Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
    Task ProductDealOfTheDayStatusChangeToTrue(int id);
    Task ProductDealOfTheDayStatusChangeToFalse(int id);
    Task<List<ResultLastFiveProductWithCategoryDto>> GetLastFiveProduct();
    Task<List<ResultLastThreeProductWithCategoryDto>> GetLastThreeProduct();
    Task CreateProduct(CreateProductDto createProductDto);
    Task<GetProductByIdDto> GetProductById(int id);
    Task<GetProductDetailByIdDto> GetProductDetailById(int id);
    Task<List<ResultPropertyWithSearchListDto>> ResultPropertyWithSearchList(string keyword, int propertyCategoryId, string city);
    Task<List<ResultProductWithCategoryDto>> GetPropertyByDealOfTheDayTrueWithCategory();
}