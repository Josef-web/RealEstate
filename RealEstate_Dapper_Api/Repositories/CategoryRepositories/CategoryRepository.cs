using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepositories;

public class CategoryRepository:ICategoryRepository
{
    private readonly Context _context;

    public CategoryRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<ResultCategoryDto>> GetAllCategory()
    {
        string query = "SELECT * FROM Category";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultCategoryDto>(query);
            return values.ToList();
        }
    }

    public async Task CreateCategory(CreateCategoryDto categoryDto)
    {
        string query = "INSERT INTO Category (CategoryName, CategoryStatus) values (@categoryName,@categoryStatus)";
        var parameters = new DynamicParameters();
        parameters.Add("@categoryName",categoryDto.CategoryName);
        parameters.Add("@categoryStatus",true);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteCategory(int id)
    {
        string query = "DELETE FROM Category WHERE CategoryID=@categoryID";
        var parameters = new DynamicParameters();
        parameters.Add("@categoryID",id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task UpdateCategory(UpdateCategoryDto categoryDto)
    {
        string query = "UPDATE Category SET CategoryName=@categoryName,CategoryStatus=@categoryStatus WHERE CategoryID=@categoryID";
        var parameters = new DynamicParameters();
        parameters.Add("@categoryName", categoryDto.CategoryName);
        parameters.Add("@categoryStatus", categoryDto.CategoryStatus);
        parameters.Add("@categoryID", categoryDto.CategoryID);
        using (var connectiont = _context.CreateConnection())
        {
            await connectiont.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetByIdCategoryDto> GetCategory(int id)
    {
        string query = "SELECT * FROM Category Where CategoryID=@categoryID";
        var parameters = new DynamicParameters();
        parameters.Add("@categoryID",id);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);
            return values;
        }
    }
}