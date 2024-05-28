using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepositories;

public class ProductRepository:IProductRepository
{
    private readonly Context _context;

    public ProductRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<List<ResultProductDto>> GetAllProductAsync()
    {
        string query = "SELECT * FROM Product";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultProductDto>(query);
            return values.ToList();
        }
    }

    public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByTrue(int id)
    {
        string query =
            "SELECT ProductID, Title, Price, CoverImage, City, District, Address, Type, DealOfTheDay, CategoryName FROM Product " +
            "INNER JOIN Category ON Product.ProductCategory=Category.CategoryID WHERE EmployeeId=@employeeId AND ProductStatus=1";
              
        var parameters = new DynamicParameters();
        parameters.Add("@employeeId",id);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
            return values.ToList();
        }
    }

    public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByFalse(int id)
    {
        string query =
            "SELECT ProductID, Title, Price, CoverImage, City, District, Address, Type, DealOfTheDay, CategoryName FROM Product " +
            "INNER JOIN Category ON Product.ProductCategory=Category.CategoryID WHERE EmployeeId=@employeeId AND ProductStatus=0";
              
        var parameters = new DynamicParameters();
        parameters.Add("@employeeId",id);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
            return values.ToList();
        }
    }

    public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
    {
        string query =
            "SELECT ProductID, Title, Price, CoverImage, City, District, Address, Type, DealOfTheDay, CategoryName FROM Product INNER JOIN Category ON Product.ProductCategory=Category.CategoryID";
                       
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
            return values.ToList();
        }
    }

    public async void ProductDealOfTheDayStatusChangeToTrue(int id)
    {
        string query = "UPDATE Product SET DealOfTheDay=1 WHERE ProductID=@productId";
        var parameters = new DynamicParameters();
        parameters.Add("@productId",id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void ProductDealOfTheDayStatusChangeToFalse(int id)
    {
        string query = "UPDATE Product SET DealOfTheDay=0 WHERE ProductID=@productId";
        var parameters = new DynamicParameters();
        parameters.Add("@productId",id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultLastFiveProductWithCategoryDto>> GetLastFiveProductAsync()
    {
        string query = "SELECT TOP(5) ProductID,Title,Price,City,District,ProductCategory,CategoryName,AdvertisementDate FROM Product INNER JOIN Category ON Product.ProductCategory=Category.CategoryID WHERE Type='Kiralık' ORDER BY ProductID DESC";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultLastFiveProductWithCategoryDto>(query);
            return values.ToList();
        }
    }

    public async  Task CreateProduct(CreateProductDto createProductDto)
    {
        string query = "INSERT INTO Product " +
                       "(Title,Price,City,District,CoverImage,Address,Description," +
                       "Type,DealOfTheDay,AdvertisementDate,ProductStatus,ProductCategory,EmployeeId) values " +
                       "(@title,@price,@city,@district,@coverImage,@address,@description,@type,@dealOfTheDay,@advertisementDate,@productStatus,@productCategory,@employeeId)";
        var parameters = new DynamicParameters();
        parameters.Add("@title",createProductDto.Title);
        parameters.Add("@price",createProductDto.Price);
        parameters.Add("@city",createProductDto.City);
        parameters.Add("@district",createProductDto.District);
        parameters.Add("@coverImage",createProductDto.CoverImage);
        parameters.Add("@address",createProductDto.Address);
        parameters.Add("@description",createProductDto.Description);
        parameters.Add("@type",createProductDto.Type);
        parameters.Add("@dealOfTheDay",createProductDto.DealOfTheDay);
        parameters.Add("@advertisementDate",createProductDto.AdvertisementDate);
        parameters.Add("@productStatus",createProductDto.ProductStatus);
        parameters.Add("@productCategory",createProductDto.ProductCategory);
        parameters.Add("@employeeId",createProductDto.EmployeeId);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}