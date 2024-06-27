using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.BottomGridDtos;
using RealEstate_Dapper_UI.Models;


namespace RealEstate_Dapper_UI.Controllers;

public class BottomGridController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;
    public BottomGridController(IHttpClientFactory httpClientFactory, ApiSettings apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings;
    }
    
    
     public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var responseMessage = await client.GetAsync("BottomGrid");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBottomGridDto>>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpGet]
    public IActionResult CreateBottomGrid()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var jsonData = JsonConvert.SerializeObject(createBottomGridDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("BottomGrid",stringContent);
    
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        
        return View();
    }
    
    public async Task<IActionResult> DeleteBottomGrid(int id)
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);;
        var responseMessage = await client.DeleteAsync($"BottomGrid/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> UpdateBottomGrid(int id)
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var responseMessage = await client.GetAsync($"BottomGrid/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateBottomGridDto>(jsonData);
            return View(values);
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var jsonData = JsonConvert.SerializeObject(updateBottomGridDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("BottomGrid/", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
    
        return View();
    }
}