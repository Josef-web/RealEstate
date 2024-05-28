using Dapper;
using RealEstate_Dapper_Api.Dtos.ServicesDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepositories;

public class ServiceRepository:IServiceRepository
{
    private readonly Context _context;

    public ServiceRepository(Context context)
    {
        _context = context;
    }
    public async Task<List<ResultServiceDto>> GetAllServiceAsync()
    {
        string query = "SELECT * FROM Service";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultServiceDto>(query);
            return values.ToList();
        }
    }

    public async void CreateService(CreateServiceDto createServiceDto)
    {
        string query = "INSERT INTO Service (ServiceName, ServiceStatus) values (@serviceName,@serviceStatus)";
        var parameters = new DynamicParameters();
        parameters.Add("@serviceName",createServiceDto.ServiceName);
        parameters.Add("@serviceStatus",true);
        
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeleteService(int id)
    {
        string query = "DELETE FROM Service WHERE ServiceID=@serviceID";
        var parameters = new DynamicParameters();
        parameters.Add("@serviceID",id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void UpdateService(UpdateServiceDto updateServiceDto)
    {
        string query = "UPDATE Service SET ServiceName=@serviceName, ServiceStatus=@serviceStatus WHERE ServiceID=@serviceID";
        var parameters = new DynamicParameters();
        parameters.Add("@serviceName", updateServiceDto.ServiceName);
        parameters.Add("@serviceStatus", updateServiceDto.ServiceStatus);
        parameters.Add("@serviceID", updateServiceDto.ServiceID);
        
        using (var connectiont = _context.CreateConnection())
        {
            await connectiont.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetByIdServiceDto> GetService(int id)
    {
        string query = "SELECT * FROM Service Where ServiceID=@serviceID";
        var parameters = new DynamicParameters();
        parameters.Add("@serviceID", id);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdServiceDto>(query, parameters);
            return values;
        }
    }
}