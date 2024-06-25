using Dapper;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreDetailRepositories;

public class WhoWeAreDetailRepository:IWhoWeAreDetailRepository
{
    private readonly Context _context;

    public WhoWeAreDetailRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetail()
    {
        string query = "SELECT * FROM WhoWeAreDetail";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
            return values.ToList();
        }
    }

    public async Task CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
    {
        string query = "INSERT INTO WhoWeAreDetail (Title, Subtitle, Description1, Description2) values (@title,@subtitle,@description1,@description2)";
        var parameters = new DynamicParameters();
        parameters.Add("@title",createWhoWeAreDetailDto.Title);
        parameters.Add("@subtitle",createWhoWeAreDetailDto.Subtitle);
        parameters.Add("@description1",createWhoWeAreDetailDto.Description1);
        parameters.Add("@description2",createWhoWeAreDetailDto.Description2);
        
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteWhoWeAreDetail(int id)
    {
        string query = "DELETE FROM WhoWeAreDetail WHERE WhoWeAreDetailID=@whoWeAreDetailID";
        var parameters = new DynamicParameters();
        parameters.Add("@whoWeAreDetailID",id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
    {
        string query = "UPDATE WhoWeAreDetail SET Title=@title,Subtitle=@subTitle,Description1=@description1,Description2=@description2 WHERE WhoWeAreDetailID=@whoWeAreDetaiID";
        var parameters = new DynamicParameters();
        parameters.Add("@title", updateWhoWeAreDetailDto.Title);
        parameters.Add("@subTitle", updateWhoWeAreDetailDto.Subtitle);
        parameters.Add("@description1", updateWhoWeAreDetailDto.Description1);
        parameters.Add("@description2", updateWhoWeAreDetailDto.Description2);
        parameters.Add("@whoWeAreDetaiID", updateWhoWeAreDetailDto.WhoWeAreDetailId);
        using (var connectiont = _context.CreateConnection())
        {
            await connectiont.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetByIdWhoWeAreDetailDto> GetWhoWeAreDetail(int id)
    {
        string query = "SELECT * FROM WhoWeAreDetail Where WhoWeAreDetailID=@whoWeAreDetailID";
        var parameters = new DynamicParameters();
        parameters.Add("@whoWeAreDetailID", id);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdWhoWeAreDetailDto>(query, parameters);
            return values;
        }
    }
}