using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;

public class PopularLocationRepository:IPopularLocationRepository
{
    private readonly Context _context;

    public PopularLocationRepository(Context contex)
    {
        _context = contex;
    }

    public async Task<List<ResultPopularLocationDto>> GetAllPopularLocation()
    {
        string query = "SELECT * FROM PopularLocation ORDER BY PropertyCount DESC";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
            return values.ToList();
        }
    }

    public async Task CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
    {
        string query = "INSERT INTO PopularLocation (CityName, ImageUrl) values (@cityName,@imageUrl)";
        var parameters = new DynamicParameters();
        parameters.Add("@cityName",createPopularLocationDto.CityName);
        parameters.Add("@imageUrl",createPopularLocationDto.ImageUrl);
        
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeletePopularLocation(int id)
    {
        string query = "DELETE FROM PopularLocation WHERE LocationID=@locationID";
        var parameters = new DynamicParameters();
        parameters.Add("@locationID",id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
    {
        string query = "UPDATE PopularLocation SET CityName=@cityName, ImageUrl=@imageUrl WHERE LocationID=@locationID";
        var parameters = new DynamicParameters();
        parameters.Add("@cityName", updatePopularLocationDto.CityName);
        parameters.Add("@imageUrl", updatePopularLocationDto.ImageUrl);
        parameters.Add("@locationID", updatePopularLocationDto.LocationID);
        
        using (var connectiont = _context.CreateConnection())
        {
            await connectiont.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetByIdPopularLocationDto> GetPopularLocation(int id)
    {
        string query = "SELECT * FROM PopularLocation Where LocationID=@locationID";
        var parameters = new DynamicParameters();
        parameters.Add("@locationID", id);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdPopularLocationDto>(query, parameters);
            return values;
        }
    }
}