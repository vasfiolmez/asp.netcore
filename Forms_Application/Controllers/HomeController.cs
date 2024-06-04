using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Forms_Application.Models;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Forms_Application.Controllers;

public class HomeController : Controller
{
    public IActionResult Index(string searchString, string category)
    {

        var products = Repository.Products;


        if (!String.IsNullOrEmpty(searchString))
        {
            ViewBag.SearchString = searchString;
            products = products.Where(p => p.Name!.ToLowerInvariant().Contains(searchString)).ToList();
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

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product model, IFormFile imageFile)
    {

        if (imageFile != null)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var extensions = Path.GetExtension(imageFile.FileName);

            if (!allowedExtensions.Contains(extensions))
            {
                ModelState.AddModelError("", "Geçerli bir resim uzantısı seçiniz");
            }
            else
            {
                var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extensions}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile!.CopyToAsync(stream);
                }
                model.Image = randomFileName;
                model.ProductId = Repository.Products.Count + 1;
                Repository.CreateProduct(model);
                return RedirectToAction("Index");
            }
        }
        else
        {
            ModelState.AddModelError("", "Lütfen bir resim seçiniz");
        }

        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(model);
    }
}
