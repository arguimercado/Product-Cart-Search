using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using ProductSearch.Models;

namespace ProductSearch.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductCartService service;

        public ProductController(ProductCartService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index(string Search = "",float Payment = 0)
        {
            IEnumerable<ProductCart> carts;
            if (string.IsNullOrEmpty(Search))
                carts = await this.service.GetProducts();
            else
                carts = await this.service.GetProductSearch(Search);
            
            return View(new TransactionModel { Carts = carts, Payment = Payment});
        }

        public async Task<IActionResult> Add(CartModel model)
        {
            var product = new Product { Name = model.Name,Description=model.Name, Cost = model.Cost};
            
            await this.service.Add(product,model.Quantity);

            return Redirect("~/Product");
        }

        public async Task<IActionResult> Delete(string Id)
        {
            await this.service.Delete(Id);

            return Redirect("~/Product");
        }


    }
}
