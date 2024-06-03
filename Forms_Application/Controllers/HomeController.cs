using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Forms_Application.Models;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Forms_Application.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string searchString, string category)
    {

        var products = Repository.Products;


        if (!String.IsNullOrEmpty(searchString))
        {
            ViewBag.SearchString = searchString;
            products = products.Where(p => p.Name.ToLowerInvariant().Contains(searchString)).ToList();
        }
        if (!String.IsNullOrEmpty(category) && category != "0")
        {
            products = products.Where(p => p.CategoryId == int.Parse(category)).ToList();
        }
        var model = new ProductViewModel
        {
            Categories = Repository.Categories,
            Products = products,
            SelectedValue = category
        };

        // @ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
