using DellChallenge.D2.Web.Models;
using DellChallenge.D2.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DellChallenge.D2.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _productService.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(NewProductModel newProduct)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(newProduct);
            }
            else
            {
                ModelState.AddModelError("", "Name is required!");
                return View(newProduct);
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(string id)
        {
            var deleteResutl = _productService.Delete(id);
            return View();
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            var product = _productService.Get(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(ProductModel model)
        {

            if (ModelState.IsValid)
            {

                var updated = _productService.Put(model.Id, model);
                if (updated == null)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }else
            {
                ModelState.AddModelError("", "Name is required!");
                return View(model);
            }
        }
    }
}