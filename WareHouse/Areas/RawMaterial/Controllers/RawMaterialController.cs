using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using WareHouse.DataAccess;
using WareHouse.Models.InformationUser;
using WareHouse.Models.ViewModels.RawMaterialsViewModel;
using WareHouse.Services;

namespace WareHouse.Areas.RawMaterial.Controllers;
[Area("RawMaterial")]
public class RawMaterialController : Controller
{
    private ApplicationDbContext _db { get; set; }
    private UserManager<IdentityUser> _userManager;

    [BindProperty]
    public EditRawMaterialViewModel EditRawMaterialViewModel { get; set; }

    public RawMaterialController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
        _db = db;
    }
    public async Task<IActionResult> Index()
    {

        if (_db.RawMaterials.Any())
        {
            var rawMaterials = _db.RawMaterials
                .OrderByDescending(item => item.Id)
                .Take(10).ToList();
            for(int i = 0; i < rawMaterials.Count; i++)
            {
                var material = rawMaterials[i];
                var user = _db.ApplicationUser.FirstOrDefault(item => item.Id.Equals(material.SupplierId));
                rawMaterials[i].Supplier = (ApplicationUser)user;
            }
            ViewBag.rawMaterials = rawMaterials;
        }
        return View();
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        EditRawMaterialViewModel = new EditRawMaterialViewModel()
        {
            RawMaterial = _db.RawMaterials.First(item => item.Id == id),
            Suppliers = _db.ApplicationUser.Select(item => new SelectListItem()
            {
                Text = item.FirstName + " " + item.LastName,
                Value = item.Id
            }),
            Currenies = _db.CurrenciesPrice
        };
        return View(EditRawMaterialViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Models.RawMaterials.RawMaterial rawMaterial)
    {
        if (ModelState.IsValid)
        {
            if (rawMaterial.Limit <= 0 || rawMaterial.NumberOfMaterial <= 0)
            {
                ModelState.AddModelError("محدود هشدار یا تعدادد محصول", "باید تعداد بیشتر مساوی از 1 باشد");
            }
            else
            {
                var user = _db.ApplicationUser.FirstOrDefault(item => item.Id.Equals(rawMaterial.SupplierId));
                if (user == null)
                {
                    ModelState.AddModelError("تامین کننده", "تامین کننده را درست وارد کنید.");
                }
                rawMaterial.DateOfBuy = CalenderService.ConvertPersianCalenderToGregorianCalender(rawMaterial.DateOfBuy);
                rawMaterial.Supplier = user;
                _db.RawMaterials.Update(rawMaterial);
                _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            }
        else
        {
        }
        EditRawMaterialViewModel.Suppliers = _db.ApplicationUser.Select(item => new SelectListItem()
        {
            Text = item.FirstName + " " + item.LastName,
            Value = item.Id
        });
        EditRawMaterialViewModel.Currenies = _db.CurrenciesPrice;
            TempData["error"] = "موفقیت آمیز نبود";
        return View(EditRawMaterialViewModel);
    }


    [HttpGet]
    public IActionResult Create()
    {
        EditRawMaterialViewModel = new EditRawMaterialViewModel()
        {
            Suppliers = _db.ApplicationUser.Select(item => new SelectListItem()
            {
                Text = item.FirstName + " " + item.LastName,
                Value = item.Id
            }),
            Currenies = _db.CurrenciesPrice

        };
        return View(EditRawMaterialViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Models.RawMaterials.RawMaterial rawMaterial)
    {
        if (ModelState.IsValid)
        {
            if (rawMaterial.Limit <= 0 || rawMaterial.NumberOfMaterial <= 0)
            {
                ModelState.AddModelError("محدود هشدار یا تعدادد محصول", "باید تعداد بیشتر مساوی از 1 باشد");
            }
            else
            {
                
                var user = _db.ApplicationUser.FirstOrDefault(item => item.Id.Equals(rawMaterial.SupplierId));
                if (user == null)
                {
                    ModelState.AddModelError("تامین کننده", "تامین کننده را درست وارد کنید.");
                }
                else
                {
                    try
                    {
                        rawMaterial.DateOfBuy = CalenderService.ConvertPersianCalenderToGregorianCalender(rawMaterial.DateOfBuy);
                        _db.RawMaterials.Add(rawMaterial);
                        _db.SaveChanges();
                        TempData["success"] = "اضافه شد.";
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("تکراری بودن", "عدد شناسایی نباید تکراری باشد.");
                    }
                }
            }
        }
        EditRawMaterialViewModel.Suppliers =  _db.ApplicationUser.Select(item => new SelectListItem()
            {
                Text = item.FirstName + " " + item.LastName,
                Value = item.Id
            });
        EditRawMaterialViewModel.Currenies = _db.CurrenciesPrice;
        TempData["error"] = "موفقیت آمیز نبود";

        return View(EditRawMaterialViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var rawMaterial = _db.RawMaterials.FirstOrDefault(item => item.Id == id);
        if (rawMaterial != null)
        {
            _db.Remove(rawMaterial);
            await _db.SaveChangesAsync();
            TempData["success"] = "باموفقیت حذف شد";
        }
        else
        {
            TempData["error"] = "موفقیت آمیز نبود";
        }
        return RedirectToAction("Index");
    }
}