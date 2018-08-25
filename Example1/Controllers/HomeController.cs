using Example1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Example1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [OutputCache(Duration = 0)]
        public PartialViewResult GetPaginatedProducts(int currentPage)
        {
            var products = new List<Product>()
            {
                new Product(1),
                new Product(2),
                new Product(3),
                new Product(4),
                new Product(5),
                new Product(6),
                new Product(7),
                new Product(8),
                new Product(9),
                new Product(10),
                new Product(11),
                new Product(12),
                new Product(13),
                new Product(14),
                new Product(15),
                new Product(16),
                new Product(17),
                new Product(18)
            };
            var paginator = new Paginator<Product>
            {
                TotalItems = products.Count
            };
            var paginatedProducts = products.Skip(paginator.ItemsPerPage * currentPage).Take(paginator.ItemsPerPage);
            paginator.Items = paginatedProducts.ToList();
            paginator.CurrentPage = currentPage;
            return PartialView("_PaginatedResults", paginator);
        } 

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}