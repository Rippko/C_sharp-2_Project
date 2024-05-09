using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly CartService _cartService;
        public BaseController(CartService cartService)
        {
            this._cartService = cartService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.CartProductCount = _cartService.Count;
            base.OnActionExecuting(context);
        }
    }
}
