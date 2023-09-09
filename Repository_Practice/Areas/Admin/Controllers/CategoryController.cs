using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository_Practice.DataAccess.Repository.IRepository;
using Repository_Practice.Model.Models;
using Repository_Practice.Utility;

namespace Repository_Practice.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Sd.Admin_Role)]
    public class CategoryController : Controller
    {
        private readonly IUniteOfWork _uniteOfWork;

        public CategoryController(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }

        public IActionResult Index()
        {
            List<Category> categoryList = _uniteOfWork.category.GetALL().ToList();

            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(ModelState.IsValid)
            {
                _uniteOfWork.category.Add(obj);
                _uniteOfWork.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
