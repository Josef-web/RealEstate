using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Models;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent;

public class _EstateAgentLastFiveProductComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;
    private readonly ILoginService _loginService;
    public _EstateAgentLastFiveProductComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService, ApiSettings apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _loginService = loginService;
        _apiSettings = apiSettings;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var id = _loginService.GetUserId;
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var responseMessage = await client.GetAsync("EstateAgentLastProducts?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLastFiveProductWithCategoryDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}