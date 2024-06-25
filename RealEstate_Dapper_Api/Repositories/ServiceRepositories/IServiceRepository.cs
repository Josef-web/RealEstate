using RealEstate_Dapper_Api.Dtos.ServicesDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepositories;

public interface IServiceRepository
{
    Task<List<ResultServiceDto>> GetAllService();
    Task CreateService(CreateServiceDto createServiceDto);
    Task DeleteService(int id);
    Task UpdateService(UpdateServiceDto updateServiceDto);
    Task<GetByIdServiceDto> GetService(int id);
}