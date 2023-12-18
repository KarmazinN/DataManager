using DataManager.BLL.Interface;
using DataManager.BOL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataManager.Ui.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyServices _companyServices;

        public CompanyController(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var companies = await _companyServices.GetCompanies();
            return View(companies);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var company = await _companyServices.GetCompaniesById(id);
            return View(company);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Company formData)
        {
            try
            {
                var result = await _companyServices.CreateNewCompany(formData);

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var company = await _companyServices.GetCompaniesById(id);

                if (company == null)
                {
                    return NotFound();
                }

                return View(company);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Company formData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _companyServices.UpadateCompany(formData);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var company = await _companyServices.GetCompaniesById(id);

                if (company == null)
                {
                    return NotFound($"Компанію з id={id} не знайдено.");
                }

                return View(company);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var company = await _companyServices.GetCompaniesById(id);

                if (company != null)
                {
                    await _companyServices.DeleteCompanyById(id);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound($"Компанію з id={id} не знайдено.");
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }
}
