﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ToDoListDtos;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.Controllers;

public class ToDoListController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;
    public ToDoListController(IHttpClientFactory httpClientFactory, ApiSettings apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var responseMessage = await client.GetAsync("ToDoLists");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultToDoListDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}