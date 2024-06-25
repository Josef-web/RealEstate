using Dapper;
using RealEstate_Dapper_Api.Dtos.SubFeatureDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.SubFeatureRepositories;

public class SubFeatureRepository:ISubFeatureRpository
{
    private readonly Context _context;

    public SubFeatureRepository(Context context)
    {
        _context = context; 
    }

    public async Task<List<ResultSubFeatureDto>> GetAllSubFeatures()
    {
        var query = "SELECT * FROM SubFeature";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultSubFeatureDto>(query);
            return values.ToList();
        }
    }
}