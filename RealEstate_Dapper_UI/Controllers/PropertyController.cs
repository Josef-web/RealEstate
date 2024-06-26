using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Packaging.Signing;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.Controllers;

public class PropertyController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public PropertyController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44350/api/Products/ProductListWithCategory");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }
        return View();
    }

    public async Task<IActionResult> PropertyListBySearch(string keyword, int propertyCategoryId, string city)
    {
        keyword = TempData["keyword"].ToString();
        propertyCategoryId = int.Parse(TempData["propertyCategoryId"].ToString());
        city = TempData["city"].ToString();
        
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:44350/api/Products/ResultPropertyWithSearchList?keyword={keyword}&propertyCategoryId={propertyCategoryId}&city={city}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultPropertyWithSearchListDto>>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpGet("property/{slug}/{id}")]
    public async Task<IActionResult> PropertyDetail(string slug, int id)
    {
        ViewBag.i = id;
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44350/api/Products/GetProductById?id=" + id);
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);
        
        var client2 = _httpClientFactory.CreateClient();
        var responseMessage2 = await client2.GetAsync("https://localhost:44350/api/ProductDetails/GetProductDetailById?id=" + id);
        var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
        var values2 = JsonConvert.DeserializeObject<GetProductDetailByIdDto>(jsonData2);
        
        ViewBag.productId = values.ProductID;
        ViewBag.title1 = values.Title;
        ViewBag.price = values.Price;
        ViewBag.city = values.City;
        ViewBag.district = values.District;
        ViewBag.address = values.Address;
        ViewBag.type = values.Type;
        ViewBag.description = values.Description;
        ViewBag.date = values.AdvertisementDate;
        ViewBag.slugUrl = values.SlugUrl;
        
        DateTime date1 = DateTime.Now; 
        DateTime date2 = values.AdvertisementDate;

        TimeSpan timespan = date1 - date2;
        int month = timespan.Days;
        ViewBag.datediff = month / 30;
        
        ViewBag.bathcount = values2.BathCount;
        ViewBag.bedroomcount = values2.BedRoomCount;
        ViewBag.productsize = values2.ProductSize;
        ViewBag.roomCount = values2.RoomCount;
        ViewBag.garageSize = values2.GarageSize;
        ViewBag.buildYear = values2.BuildYear;
        ViewBag.location = values2.Location;
        ViewBag.videoUrl = values2.VideoUrl;

        string slugFromTitle = CreateSlug(values.Title);
        ViewBag.slugUrl = slugFromTitle;
        
        return View();
    }

    private string CreateSlug(string title)
    {
        title = title.ToLowerInvariant(); // Küçük harfe çevir
        title = title.Replace(" ", "-"); // Boşlukları tire ile değiştir
        title = System.Text.RegularExpressions.Regex.Replace(title, @"[^a-z0-9\s-]", ""); // Geçersiz karakterleri kaldır
        title = System.Text.RegularExpressions.Regex.Replace(title, @"\s+", " ").Trim(); // Birden fazla boşluğu tek boşluğa indir ve kenar boşluklarını kaldır
        title = System.Text.RegularExpressions.Regex.Replace(title, @"\s", "-"); // Boşlukları tire ile değiştir

        return title;
    }
}