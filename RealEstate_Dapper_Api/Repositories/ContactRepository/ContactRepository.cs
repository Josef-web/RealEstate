using Dapper;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ContactRepository;

public class ContactRepository:IContactRepository
{
    private readonly Context _context;
    
    public ContactRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<List<ResultContactDto>> GetAllContactAsync()
    {
        string query = "SELECT * FROM Contact";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultContactDto>(query);
            return values.ToList();
        }
    }

    public async Task<List<LastFourContactResultDto>> GetLastFourContact()
    {
        string query = "SELECT TOP(4)* FROM Contact ORDER BY ContactID DESC";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<LastFourContactResultDto>(query);
            return values.ToList();
        }
    }

    public void CreateContact(CreateContactDto createContactDto)
    {
        throw new NotImplementedException();
    }

    public void DeleteContact(int id)
    {
        throw new NotImplementedException();
    }

    public Task<GetByIdContactDto> GetContact(int id)
    {
        throw new NotImplementedException();
    }
}