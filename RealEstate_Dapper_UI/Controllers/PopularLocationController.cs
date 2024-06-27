using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.PopularLocationDtos;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.Controllers;

public class PopularLocationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;
    public PopularLocationController(IHttpClientFactory httpClientFactory, ApiSettings apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings;
    }
    
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var responseMessage = await client.GetAsync("PopularLocation");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultPopularLocationDto>>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpGet]
    public IActionResult CreatePopularLocation()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var jsonData = JsonConvert.SerializeObject(createPopularLocationDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("PopularLocation",stringContent);
    
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        
        return View();
    }
    
    public async Task<IActionResult> DeletePopularLocation(int id)
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var responseMessage = await client.DeleteAsync($"PopularLocation/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> UpdatePopularLocation(int id)
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var responseMessage = await client.GetAsync($"PopularLocation/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdatePopularLocationDto>(jsonData);
            return View(values);
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var jsonData = JsonConvert.SerializeObject(updatePopularLocationDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("PopularLocation/", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
    
        return View();
    }
    
}