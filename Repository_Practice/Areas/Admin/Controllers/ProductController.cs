using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository_Practice.DataAccess.Repository.IRepository;
using Repository_Practice.Model.Models;
using Repository_Practice.Utility;

namespace Repository_Practice.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Sd.Admin_Role)]
    public class ProductController : Controller
    {
        private readonly IUniteOfWork _uniteOfWork;

        public ProductController(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }

        public IActionResult Index()
        {
            List<Product> productList = _uniteOfWork.product.GetALL(includePropertyes: "Category").ToList();
            return View(productList);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> categoryList = _uniteOfWork.category.GetALL().Select(u => new SelectListItem
            {
                Text = u.CategoryName,
                Value = u.Id.ToString(),
            });
            ViewBag.Category = categoryList;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if(ModelState.IsValid)
            {
                _uniteOfWork.product.Add(obj);
                _uniteOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                IEnumerable<SelectListItem> categoryList = _uniteOfWork.category.GetALL().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.Id.ToString(),
                });
                ViewBag.Category = categoryList;
            }

            return View();
        }

    }
}
