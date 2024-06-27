using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.AppUserDtos;
using RealEstate_Dapper_UI.Models;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.PropertyDetail;

public class _PropertyAppUserComponentPartial:ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILoginService _loginService;
    private readonly ApiSettings _apiSettings;
    public _PropertyAppUserComponentPartial(IHttpClientFactory httpClientFactory, ApiSettings apiSettings, ILoginService loginService)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings;
        _loginService = loginService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        // TODO: Kesin doğru olmayabilir
        var id = _loginService.GetUserId;

        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var responseMessage = await client.GetAsync("AppUsers?id="+id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetAppUserByProductIdDto>(jsonData);
            return View(values);
        }

        return View();
    }
}