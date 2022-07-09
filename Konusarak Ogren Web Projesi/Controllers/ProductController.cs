using BusinessLayer.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Konusarak_Ogren_Web_Projesi.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        public IActionResult ListAll()
        {
            List<Product> products = productRepository.GetAll();
            return View(products);
        }
        public IActionResult Comments(int productId)
        {
            List<Comment> comments = productRepository.GetComments(productId);
            return View(comments);
        }
    }
}
