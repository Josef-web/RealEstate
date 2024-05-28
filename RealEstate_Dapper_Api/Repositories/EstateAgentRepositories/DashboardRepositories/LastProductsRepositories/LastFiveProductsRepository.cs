using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories;

public class LastFiveProductsRepository:ILastFiveProductsRepository
{
    private readonly Context _context;

    public LastFiveProductsRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<List<ResultLastFiveProductWithCategoryDto>> GetLastFiveProductAsync(int id)
    {
        string query = "SELECT TOP(5) ProductID,Title,Price,City,District,ProductCategory,CategoryName,AdvertisementDate FROM Product INNER JOIN Category ON Product.ProductCategory=Category.CategoryID WHERE EmployeeID=@employeeId ORDER BY ProductID DESC";
        var parameters = new DynamicParameters();
        parameters.Add("@employeeId",id);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultLastFiveProductWithCategoryDto>(query,parameters);
            return values.ToList();
        }
    }
}