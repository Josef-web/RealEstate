﻿using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ToDoListRepositories;

namespace RealEstate_Dapper_Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class ToDoListsController : ControllerBase
{
   private readonly IToDoListRepository _toDoListRepository;

   public ToDoListsController(IToDoListRepository toDoListRepository)
   {
      _toDoListRepository = toDoListRepository;
   }

   [HttpGet]
   public async Task<IActionResult> ToDoList()
   {
      var values = await _toDoListRepository.GetAllToDoList();
      return Ok(values);
   }
}