﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.LoginDtos;
using RealEstate_Dapper_UI.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace RealEstate_Dapper_UI.Controllers;

public class LoginController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;
    public LoginController(IHttpClientFactory httpClientFactory, ApiSettings apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var content = new StringContent(JsonSerializer.Serialize(createLoginDto), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("Login", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            if (tokenModel != null)
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(tokenModel.Token);
                var claims = token.Claims.ToList();
                if (tokenModel.Token != null)
                {
                    claims.Add(new Claim("realestatetoken", tokenModel.Token));
                    var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                    var authProps = new AuthenticationProperties
                    {
                        ExpiresUtc = tokenModel.ExpireDate,
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), authProps);
                    return RedirectToAction("Index", "Employee");
                }
            }
        }
        return View();
    }
}