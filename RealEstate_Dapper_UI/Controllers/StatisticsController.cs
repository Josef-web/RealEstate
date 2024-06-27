using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Models;
using Microsoft.Extensions.Options;

namespace RealEstate_Dapper_UI.Controllers;

public class StatisticsController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;
    public StatisticsController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings.Value;
    }

    public async Task<IActionResult> Index()
    {
        #region Aktif Kategori
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var responseMessage = await client.GetAsync("Statistics/ActiveCategoryCount");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        ViewBag.activeCategoryCount = jsonData;
        #endregion
        
        #region Aktif Personel
        var client2 = _httpClientFactory.CreateClient();
        var responseMessage2 = await client2.GetAsync("Statistics/ActiveEmployeeCount");
        var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
        ViewBag.activeEmployeeCount = jsonData2;
        #endregion
        
        #region Daire Sayısı
        var client3 = _httpClientFactory.CreateClient();
        var responseMessage3 = await client3.GetAsync("Statistics/ApartmentCount");
        var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
        ViewBag.apartmentCount = jsonData3;
        #endregion
        
        #region Ortalama Kira Fiyatı
        var client4 = _httpClientFactory.CreateClient();
        var responseMessage4 = await client4.GetAsync("Statistics/AverageProductPriceByRent");
        var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
        ViewBag.averageProductPriceByRent = jsonData4;
        #endregion
        
        
        #region Ortalama Satış Fiyatı
        var client5 = _httpClientFactory.CreateClient();
        var responseMessage5 = await client5.GetAsync("Statistics/AverageProductPriceBySale");
        var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
        ViewBag.averageProductPriceBySale = jsonData5;
        #endregion
        
        #region Ortalama Oda Sayısı
        var client6 = _httpClientFactory.CreateClient();
        var responseMessage6 = await client6.GetAsync("Statistics/AverageRoomCount");
        var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
        ViewBag.averageRoomCount = jsonData6;
        #endregion
        
        #region Kategori Sayısı
        var client7 = _httpClientFactory.CreateClient();
        var responseMessage7 = await client7.GetAsync("Statistics/CategoryCount");
        var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
        ViewBag.categoryCount = jsonData7;
        #endregion
        
        #region En Fazla İlanlı Kategori
        var client8 = _httpClientFactory.CreateClient();
        var responseMessage8 = await client8.GetAsync("Statistics/CategoryNameByMaxProductCount");
        var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
        ViewBag.categoryNameByMaxProductCount = jsonData8;
        #endregion
        
        
        #region En Fazla İlanlı Şehir
        var client9 = _httpClientFactory.CreateClient();
        var responseMessage9 = await client9.GetAsync("Statistics/CityNameByMaxProductCount");
        var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
        ViewBag.cityNameByMaxProductCount = jsonData9;
        #endregion
        
        #region Şehir Sayısı
        var client10 = _httpClientFactory.CreateClient();
        var responseMessage10 = await client10.GetAsync("Statistics/DifferentCityCount");
        var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
        ViewBag.differentCityCount = jsonData10;
        #endregion
        
        #region En Fazla İlana Sahip Personel
        var client11 = _httpClientFactory.CreateClient();
        var responseMessage11 = await client11.GetAsync("Statistics/EmployeeNameByMaxProductCount");
        var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
        ViewBag.employeeNameByMaxProductCount = jsonData11;
        #endregion
        
        #region Son İlan Fiyatı
        var client12 = _httpClientFactory.CreateClient();
        var responseMessage12 = await client12.GetAsync("Statistics/LastProductPrice");
        var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
        ViewBag.lastProductPrice = jsonData12;
        #endregion
        
        
        #region En Yeni Bina Yaşı
        var client13 = _httpClientFactory.CreateClient();
        var responseMessage13 = await client13.GetAsync("Statistics/NewestBuildingYear");
        var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
        ViewBag.newestBuildingYear = jsonData13;
        #endregion
        
        #region En Eski Bina Yaşı
        var client14 = _httpClientFactory.CreateClient();
        var responseMessage14 = await client14.GetAsync("Statistics/OldestBuildingYear");
        var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
        ViewBag.oldestBuildingYear = jsonData14;
        #endregion
        
        #region Pasif Kategori
        var client15 = _httpClientFactory.CreateClient();
        var responseMessage15 = await client15.GetAsync("Statistics/PassiveCategoryCount");
        var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
        ViewBag.passiveCategoryCount = jsonData15;
        #endregion
        
        #region Toplam İlan
        var client16 = _httpClientFactory.CreateClient();
        var responseMessage16 = await client16.GetAsync("Statistics/ProductCount");
        var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
        ViewBag.productCount = jsonData16;
        #endregion
        
        
        
        return View();
    }
}