using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard;

public class _DashboardLastFiveProductComponentPartial:ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DashboardLastFiveProductComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var cleint = _httpClientFactory.CreateClient();
        var responseMessage = await cleint.GetAsync("https://localhost:44350/api/Products/LastFiveProductList");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLastFiveProductWithCategoryDto>>(jsonData);
            return View(values);
        }

        return View();
    }

    
}