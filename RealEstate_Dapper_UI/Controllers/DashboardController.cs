using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Controllers;

public class DashboardController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}