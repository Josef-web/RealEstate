using RealEstate_Dapper_Api.Dtos.ServicesDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepositories;

public interface IServiceRepository
{
    Task<List<ResultServiceDto>> GetAllServiceAsync();
    void CreateService(CreateServiceDto createServiceDto);
    void DeleteService(int id);
    void UpdateService(UpdateServiceDto updateServiceDto);
    Task<GetByIdServiceDto> GetService(int id);
}