using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MVC.Models;

namespace MVC.Controllers
{
    public class EshopController : BaseController
    {
        private readonly ProductService _productService;
        public EshopController(ProductService productService, CartService cartService)
            :base(cartService)
        {
            this._productService = productService;
        }
        public IActionResult Index()
        {
            ViewBag.Products = this._productService.List();
            return View();
        }
        public IActionResult Detail(int id)
        {
            Product p = this._productService.Find(id);
            if (p == null)
            {
                return NotFound();
            }
            ViewBag.Product = p;
            return View();
        }

        public IActionResult Add(int id)
        {
            this._cartService.Add(this._productService.Find(id));
            return RedirectToAction("Detail", new { id = id});
        }

        public IActionResult Form()
        {
            ViewBag.CartProducts = this._productService.List();
            return View();
        }
        [HttpPost]
        public IActionResult Form(OrderForm form) 
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Done");
            }
            ViewBag.CartProducts = this._productService.List();
            return View();
        }
        public ActionResult Done() 
        {
            return View();
        }
        public IActionResult GetJson(int limit)
        {
            return new JsonResult(this._productService.List().Take(limit));
        }

    }
}
