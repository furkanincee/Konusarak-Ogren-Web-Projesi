using DataAccessLayer.Context;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Konusarak_Ogren_Web_Projesi.Controllers
{
    public class UserController : Controller
    {
        private readonly ETradeDbContext _db = new ETradeDbContext();
      
        public IActionResult Index(User user)
        {
            if (user.RoleId == 2)
            {
                return RedirectToAction("ListAll", "Product");
            }
            else if(user.RoleId == 1)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "SysAdmin");
            }
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            User user0 = new User();
            user0.Name = "sysadmin";
            user0.Surname = "soyad";
            user0.Email = "sysadmin@hotmail.com";
            user0.Password = "123456";
            user0.RoleId = 0;
            _db.Users.Add(user0);
            _db.SaveChanges();
            User user1 = new User();
            user1.Name = "admin";
            user1.Surname = "soyad";
            user1.Email = "admin@hotmail.com";
            user1.Password = "123456";
            user1.RoleId = 1;
            _db.Users.Add(user1);
            _db.SaveChanges();
            User user2 = new User();
            user2.Name = "customer";
            user2.Surname = "soyad";
            user2.Email = "customer@hotmail.com";
            user2.Password = "123456";
            user2.RoleId = 2;
            _db.Users.Add(user2);
            _db.SaveChanges();
            Category category = new Category();
            category.Name = "kategori";
            category.Description = "denemekategorisi";
            _db.Categories.Add(category);
            _db.SaveChanges();
            Brand brand = new Brand();
            brand.BrandName = "marka";
            _db.Brands.Add(brand);
            _db.SaveChanges();
            Product product1 = new Product();
            product1.Name = "ürün1";
            product1.Brand = brand;
            product1.Description = "açıklama";
            product1.Color = "Kırmızı";
            product1.Size = "XL";
            product1.Price = 10;
            product1.Category = category;
            _db.Products.Add(product1);
            _db.SaveChanges();
        
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(User data)
        {
           
            User user = _db.Users.FirstOrDefault(x => x.Email == data.Email && x.Password == data.Password);

            if (user != null)
            {
                List<Claim> userClaims = new List<Claim>();
                userClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                userClaims.Add(new Claim(ClaimTypes.Role, user.RoleId.ToString()));
                userClaims.Add(new Claim(ClaimTypes.Name, user.Name));

                var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),
       authProperties);
                return RedirectToAction("Index", "User", user);

            }
            else
            {
                return View(user);
            }
        }


    }
}
