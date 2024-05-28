using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ServicesDto;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDetailDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage;

public class _DefaultWhoWeAreComponentPartial:ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var client2 = _httpClientFactory.CreateClient();
        
        var responseMessage = await client.GetAsync("https://localhost:44350/api/WhoWeAreDetails");
        var responseMessage2 = await client2.GetAsync("https://localhost:44350/api/Services");
        
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