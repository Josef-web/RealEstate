using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.PropertyImageDtos;

namespace RealEstate_Dapper_UI.ViewComponents.PropertyDetail;

public class _PropertySliderComponentPartial:ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _PropertySliderComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var cleint = _httpClientFactory.CreateClient();
        var responseMessage = await cleint.GetAsync("https://localhost:44350/api/ProductImages?id=1");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<PropertyImageDto>>(jsonData);
            return View(values);
        }

        return View();
    }
}