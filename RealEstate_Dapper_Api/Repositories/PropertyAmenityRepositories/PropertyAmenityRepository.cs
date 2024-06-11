using Dapper;
using RealEstate_Dapper_Api.Dtos.PropertyAmenityDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PropertyAmenityRepositories;

public class PropertyAmenityRepository:IPropertyAmenityRepository
{
    private readonly Context _context;

    public PropertyAmenityRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<List<ResultPropertyAmenityByStatusTrueDto>> ResultPropertyAmenityByStatusTrue(int id)
    {
        string query = "SELECT PropertyAmenityId, Title FROM PropertyAmenity INNER JOIN Amenity ON Amenity.AmenityId=PropertyAmenity.AmenityId WHERE PropertyId=@propertyId AND Status=1";
        var parameters = new DynamicParameters();
        parameters.Add("@propertyId",id);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultPropertyAmenityByStatusTrueDto>(query,parameters);
            return values.ToList();
        }
    }
}