﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ContactRepository;

namespace RealEstate_Dapper_Api.Controller;


[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly IContactRepository _contactRepository;

    public ContactsController(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    [HttpGet("GetLastFourContact")]
    public async Task<IActionResult> GetLastFourContact()
    {
        var values = await _contactRepository.GetLastFourContact();
        return Ok(values);
    }
    
}