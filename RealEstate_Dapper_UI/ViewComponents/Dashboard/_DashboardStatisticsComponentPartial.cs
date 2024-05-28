﻿using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard;

public class _DashboardStatisticsComponentPartial:ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        #region Toplam İlan
        var client1 = _httpClientFactory.CreateClient();
        var responseMessage1 = await client1.GetAsync("https://localhost:44350/api/Statistics/ProductCount");
        var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
        ViewBag.productCount = jsonData1;
        #endregion
        
        #region En Fazla İlana Sahip Personel
        var client2 = _httpClientFactory.CreateClient();
        var responseMessage2 = await client2.GetAsync("https://localhost:44350/api/Statistics/EmployeeNameByMaxProductCount");
        var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
        ViewBag.employeeNameByMaxProductCount = jsonData2;
        #endregion
        
        #region Şehir Sayısı
        var client3 = _httpClientFactory.CreateClient();
        var responseMessage3 = await client3.GetAsync("https://localhost:44350/api/Statistics/DifferentCityCount");
        var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
        ViewBag.differentCityCount = jsonData3;
        #endregion
        
        #region Ortalama Kira Fiyatı
        var client4 = _httpClientFactory.CreateClient();
        var responseMessage4 = await client4.GetAsync("https://localhost:44350/api/Statistics/AverageProductPriceByRent");
        var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
        ViewBag.averageProductPriceByRent = jsonData4;
        #endregion
        
        return View();
    }
}