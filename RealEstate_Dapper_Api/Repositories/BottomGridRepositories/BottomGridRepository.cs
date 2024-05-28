using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories;

public class BottomGridRepository:IBottomGridRepository
{
    private readonly Context _context;

    public BottomGridRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
    {
        string query = "SELECT * FROM BottomGrid";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultBottomGridDto>(query);
            return values.ToList();
        }
    }

    public async void CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
    {
        string query = "INSERT INTO BottomGrid (Icon, Title, Description) values (@icon,@title,@description)";
        var parameters = new DynamicParameters();
        parameters.Add("@icon",createBottomGridDto.Icon);
        parameters.Add("@title",createBottomGridDto.Title);
        parameters.Add("@description",createBottomGridDto.Description);
        
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeleteBottomGrid(int id)
    {
        string query = "DELETE FROM BottomGrid WHERE BottomGridID=@bottomGridID";
        var parameters = new DynamicParameters();
        parameters.Add("@bottomGridID",id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
    {
        string query = "UPDATE BottomGrid SET Icon=@icon, Title=@title, Description=@description WHERE BottomGridID=@bottomGridID";
        var parameters = new DynamicParameters();
        parameters.Add("@icon", updateBottomGridDto.Icon);
        parameters.Add("@title", updateBottomGridDto.Title);
        parameters.Add("@description", updateBottomGridDto.Description);
        parameters.Add("@bottomGridID", updateBottomGridDto.BottomGridID);
        
        using (var connectiont = _context.CreateConnection())
        {
            await connectiont.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetBottomGridDto> GetBottomGrid(int id)
    {
        string query = "SELECT * FROM BottomGrid Where BottomGridID=@bottomGridID";
        var parameters = new DynamicParameters();
        parameters.Add("@bottomGridID", id);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryFirstOrDefaultAsync<GetBottomGridDto>(query, parameters);
            return values;
        }
    }
}