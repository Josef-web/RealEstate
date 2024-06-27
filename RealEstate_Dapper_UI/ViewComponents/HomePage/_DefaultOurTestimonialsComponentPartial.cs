﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.TestimonialDtos;
using RealEstate_Dapper_UI.Models;
using Microsoft.Extensions.Options;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage;

public class _DefaultOurTestimonialsComponentPartial:ViewComponent
{
    
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;
    public _DefaultOurTestimonialsComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings.Value;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var responseMessage = await client.GetAsync("Testimonials");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTesimonialDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}