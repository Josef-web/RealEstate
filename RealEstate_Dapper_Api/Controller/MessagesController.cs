using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.MessageRepositories;
using Swashbuckle.AspNetCore.Annotations;

namespace RealEstate_Dapper_Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly IMessageRepository _messageRepository;

    public MessagesController(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get the last three messages in the inbox for a specific receiver", 
        Description = "Returns the last three messages received by a user with the specified ID.")]
    public async Task<IActionResult> GetInBoxLastThreeMessageListByReceiver(int id)
    {
        var values = await _messageRepository.GetInBoxLastThreeMessageListByReceiver(id);
        return Ok(values);
    }
}