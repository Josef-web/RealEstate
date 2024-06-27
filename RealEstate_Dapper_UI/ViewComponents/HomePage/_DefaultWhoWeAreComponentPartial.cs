using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ServicesDto;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage;

public class _DefaultWhoWeAreComponentPartial:ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;
    public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory, ApiSettings apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        
        var client2 = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        
        var responseMessage = await client.GetAsync("WhoWeAreDetails");
        var responseMessage2 = await client2.GetAsync("Services");
        
        if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            
            var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailsDto>>(jsonData);
            var value2 = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData2);
            
            ViewBag.title = value.Select(x=>x.Title).FirstOrDefault() ?? throw new InvalidOperationException();
            ViewBag.subTitle = value.Select(x=>x.Subtitle).FirstOrDefault() ?? throw new InvalidOperationException();
            ViewBag.description1 = value.Select(x=>x.Description1).FirstOrDefault() ?? throw new InvalidOperationException();
            ViewBag.description2 = value.Select(x=>x.Description2).FirstOrDefault() ?? throw new InvalidOperationException();
            return View(value2);
        }
        return View();
    }
}