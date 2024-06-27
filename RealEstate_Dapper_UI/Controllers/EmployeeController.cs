using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.EmployeeDtos;
using RealEstate_Dapper_UI.Models;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.Controllers;

[Authorize]
public class EmployeeController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILoginService _loginService;
    private readonly ApiSettings _apiSettings;
    public EmployeeController(IHttpClientFactory httpClientFactory, ILoginService loginService, ApiSettings apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _loginService = loginService;
        _apiSettings = apiSettings;
    }

    public async Task<IActionResult> Index()
    {
        var user = User.Claims;
        var userId = _loginService.GetUserId;
        var token = User.Claims.FirstOrDefault(x => x.Type == "realestatetoken")?.Value;
        
        if (token != null)
        {
            var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.GetAsync("Employees");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonData);
                return View(values);
            }
        }
        return View();
    }

    [HttpGet]
    public IActionResult CreateEmployee()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var jsonData = JsonConvert.SerializeObject(createEmployeeDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("Employees",stringContent);
    
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        
        return View();
    }
    
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var responseMessage = await client.DeleteAsync($"Employees/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> UpdateEmployee(int id)
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var responseMessage = await client.GetAsync($"Employees/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateEmployeeDto>(jsonData);
            return View(values);
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var jsonData = JsonConvert.SerializeObject(updateEmployeeDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("Employees/", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
    
        return View();
    }
}