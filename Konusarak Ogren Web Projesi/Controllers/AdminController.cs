using BusinessLayer.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Konusarak_Ogren_Web_Projesi.Controllers
{
    public class AdminController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        UserRepository userRepository = new UserRepository();
        
        public IActionResult Index()
        {
            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier));
            int brandId = userRepository.GetBrandId(userId);
            return RedirectToAction("ListBrandProducts", brandId);
        }
        public IActionResult ListBrandProducts(int brandId)
        {        
            return View(productRepository.GetByBrand(brandId));
        }
        public IActionResult DeleteProduct(Product product)
        {
            productRepository.Delete(product);
            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier));
            int brandId = userRepository.GetBrandId(userId);
            return RedirectToAction("ListBrandProducts",userId);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            productRepository.Insert(product);
            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier));
            int brandId = userRepository.GetBrandId(userId);
            return RedirectToAction("ListBrandProducts",userId);
        }

        public IActionResult AddProduct()
        {
            return View();
        }
    }
}
