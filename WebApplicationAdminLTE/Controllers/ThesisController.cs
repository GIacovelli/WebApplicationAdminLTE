using Microsoft.AspNetCore.Mvc;

namespace WebApplicationAdminLTE.Controllers;

public class ThesisController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}