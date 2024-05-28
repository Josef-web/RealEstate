using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories;

public class ToDoListRepository: IToDoListRepository
{
    
    private readonly Context _context;

    public ToDoListRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<ResultToDoListDto>> GetAllToDoListAsync()
    {
        string query = "SELECT * FROM ToDoList";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultToDoListDto>(query);
            return values.ToList();
        }
    }

    public void CreateToDoList(CreateToDoListDto ToDoListDto)
    {
        throw new NotImplementedException();
    }

    public void DeleteToDoList(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateToDoList(UpdateToDoListDto ToDoListDto)
    {
        throw new NotImplementedException();
    }

    public Task<GetByIdToDoListDto> GetToDoList(int id)
    {
        throw new NotImplementedException();
    }
}