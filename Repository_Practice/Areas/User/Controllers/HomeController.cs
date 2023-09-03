using Microsoft.AspNetCore.Mvc;
using Repository_Practice.DataAccess.Repository.IRepository;
using Repository_Practice.Model.Models;
using Repository_Practice.Models;
using System.Diagnostics;

namespace Repository_Practice.Areas.User.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUniteOfWork _uniteOfWork;
        public HomeController(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }

        public IActionResult Index()
        {
            List<Product> products = _uniteOfWork.product.GetALL("Category").ToList();
            return View(products);
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
}