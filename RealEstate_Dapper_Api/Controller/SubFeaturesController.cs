using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.SubFeatureRepositories;

namespace RealEstate_Dapper_Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class SubFeaturesController : ControllerBase
{
    private readonly ISubFeatureRpository _subFeatureRpository;

    public SubFeaturesController(ISubFeatureRpository subFeatureRpository)
    {
        _subFeatureRpository = subFeatureRpository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSubFeaturesAsync()
    {
        var values = await _subFeatureRpository.GetAllSubFeatures();
        return Ok(values);
    }
}