using RealEstate_Dapper_Api.Dtos.ProductDetailDto;
using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepositories;

public interface IProductRepository
{
    Task<List<ResultProductDto>> GetAllProductAsync();
    Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByTrue(int id);
    Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByFalse(int id);
    Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
    Task ProductDealOfTheDayStatusChangeToTrue(int id);
    Task ProductDealOfTheDayStatusChangeToFalse(int id);
    Task<List<ResultLastFiveProductWithCategoryDto>> GetLastFiveProductAsync();
    Task<List<ResultLastThreeProductWithCategoryDto>> GetLastThreeProductAsync();
    Task CreateProduct(CreateProductDto createProductDto);
    Task<GetProductByIdDto> GetProductById(int id);
    Task<GetProductDetailByIdDto> GetProductDetailById(int id);
    Task<List<ResultPropertyWithSearchListDto>> ResultPropertyWithSearchList(string keyword, int propertyCategoryId, string city);
    Task<List<ResultProductWithCategoryDto>> GetPropertyByDealOfTheDayTrueWithCategoryAsync();
}