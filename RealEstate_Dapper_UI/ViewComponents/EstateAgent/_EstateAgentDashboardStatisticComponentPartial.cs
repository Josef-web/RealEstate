using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Models;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent;

public class _EstateAgentDashboardStatisticComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILoginService _loginService;
    private readonly ApiSettings _apiSettings;
    public _EstateAgentDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService, ApiSettings apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _loginService = loginService;
        _apiSettings = apiSettings;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var id = _loginService.GetUserId;
        
        #region Toplam İlan
        var client1 = _httpClientFactory.CreateClient();
        client1.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var responseMessage1 = await client1.GetAsync("EstateAgentDashboardStatistic/AllProductCount");
        var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
        ViewBag.productCount = jsonData1;
        #endregion
        
        #region Emlakçının Toplam İlan Sayısı
        var client2 = _httpClientFactory.CreateClient();
        client2.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var responseMessage2 = await client2.GetAsync("EstateAgentDashboardStatistic/ProductCountByEmployeeId?id=" + id);
        var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
        ViewBag.employeeByProductCount = jsonData2;
        #endregion
        
        #region Aktif İlan Sayısı
        var client3 = _httpClientFactory.CreateClient();
        client3.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var responseMessage3 = await client3.GetAsync("EstateAgentDashboardStatistic/ProductCountByStatusTrue?id=" + id);
        var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
        ViewBag.productCountByEmployeeStatusTrue = jsonData3;
        #endregion
        
        #region Ortalama Kira Fiyatı
        var client4 = _httpClientFactory.CreateClient();
        client4.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var responseMessage4 = await client4.GetAsync("EstateAgentDashboardStatistic/ProductCountByStatusFalse?id=" + id);
        var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
        ViewBag.productCountByEmployeeStatusFalse = jsonData4;
        #endregion
        
        return View();
    }
}