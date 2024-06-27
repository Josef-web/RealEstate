using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.MessageDtos;
using RealEstate_Dapper_UI.Models;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.ViewComponents.EstateAgentNavbarViewComponents;

public class _NavbarLastThreeMessageComponentPartial:ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILoginService _loginService;
    private readonly ApiSettings _apiSettings;
    public _NavbarLastThreeMessageComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService, ApiSettings apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _loginService = loginService;
        _apiSettings = apiSettings;
    }
    public async Task<ViewViewComponentResult> InvokeAsync()
    {
        var id = _loginService.GetUserId;
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var responseMessage = await client.GetAsync("Messages?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultInBoxMessageDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}