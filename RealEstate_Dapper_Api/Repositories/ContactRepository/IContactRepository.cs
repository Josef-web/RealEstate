using RealEstate_Dapper_Api.Dtos.ContactDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepository;

public interface IContactRepository
{
    Task<List<ResultContactDto>> GetAllContact();
    Task<List<LastFourContactResultDto>> GetLastFourContact();
    Task CreateContact(CreateContactDto createContactDto);
    Task DeleteContact(int id);
    Task<GetByIdContactDto> GetContact(int id);
}