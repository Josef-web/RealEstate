using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Repositories.WhoWeAreDetailRepositories;

namespace RealEstate_Dapper_Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class WhoWeAreDetailsController : ControllerBase
{
    private readonly IWhoWeAreDetailRepository _whoWeAreDetailRepository;

    public WhoWeAreDetailsController(IWhoWeAreDetailRepository whoWeAreDetailRepository)
    {
        _whoWeAreDetailRepository = whoWeAreDetailRepository;
    }


    [HttpGet]
    public async Task<IActionResult> WhoWeAreDetailList()
    {
        var values = await _whoWeAreDetailRepository.GetAllWhoWeAreDetailAsync();
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
    {
        _whoWeAreDetailRepository.CreateWhoWeAreDetail(createWhoWeAreDetailDto);
        return Ok("About Us added successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
    {
        _whoWeAreDetailRepository.DeleteWhoWeAreDetail(id);
        return Ok("About Us deleted successfully");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
    {
        _whoWeAreDetailRepository.UpdateWhoWeAreDetail(updateWhoWeAreDetailDto);
        return Ok("About Us updated successfully");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWhoWeAreDetail(int id)
    {
        var value = await _whoWeAreDetailRepository.GetWhoWeAreDetail(id);
        return Ok(value);
    }
}