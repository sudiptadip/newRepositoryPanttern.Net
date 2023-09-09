using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository_Practice.DataAccess.Repository.IRepository;
using Repository_Practice.Model.Models;
using Repository_Practice.Utility;

namespace Repository_Practice.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Authorize(Roles = Sd.Admin_Role)]
    public class CompanyController : Controller
    {
        private readonly IUniteOfWork _uniteOfWork;

        public CompanyController(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }

        public IActionResult Index()
        {
            List<Company> companyList = _uniteOfWork.company.GetALL().ToList();
            return View(companyList);
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
        public IActionResult Create(Company obj)
        {
            if(ModelState.IsValid)
            {
                _uniteOfWork.company.Add(obj);
                _uniteOfWork.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
