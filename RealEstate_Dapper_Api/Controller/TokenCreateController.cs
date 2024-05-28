using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class TokenCreateController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateToken(GetCheckAppUserViewModel model)
    {
        var values = JwtTokenGenerator.GenerateToken(model);
        return Ok(values);
    }
}