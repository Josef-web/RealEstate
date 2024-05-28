using Dapper;
using RealEstate_Dapper_Api.Dtos.MessageDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.MessageRepositories;

public class MessageRepository:IMessageRepository
{
    private readonly Context _context;

    public MessageRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<List<ResultInBoxMessageDto>> GetInBoxLastThreeMessageListByReceiver(int id)
    {
        string query = "SELECT TOP(3) MessageId, Name, Subject, MessageDetail, SendDate, IsRead, UserImageUrl FROM Message INNER JOIN  AppUser " +
                       "ON Message.Sender=AppUser.UserId WHERE Receiver=@receiverId ORDER BY MessageId DESC";
        var parameters = new DynamicParameters();
        parameters.Add("@receiverId",id);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultInBoxMessageDto>(query, parameters);
            return values.ToList();
        }
    }
}