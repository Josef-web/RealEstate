using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.AppUserDtos;
using RealEstate_Dapper_UI.Dtos.PropertyImageDtos;

namespace RealEstate_Dapper_UI.ViewComponents.PropertyDetail;

public class _PropertyAppUserComponentPartial:ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _PropertyAppUserComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var cleint = _httpClientFactory.CreateClient();
        var responseMessage = await cleint.GetAsync("https://localhost:44350/api/AppUsers?id=1");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetAppUserByProductIdDto>(jsonData);
            return View(values);
        }

        return View();
    }
}