using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Controllers;

public class DefaultController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}