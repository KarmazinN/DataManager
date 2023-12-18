using DataManager.BLL.Interface;
using DataManager.BLL.Services;
using DataManager.BOL.Common;
using DataManager.BOL.Entity;
using DataManager.BOL.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DataManager.Ui.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        private readonly ICompanyServices _companyServices;
        private readonly IDepartamentServices _departamentServices;
        private readonly IPositionServices _positionServices;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmployeeController(IEmployeeServices employeeServices, ICompanyServices companyServices, IDepartamentServices departamentServices, IPositionServices positionServices, IWebHostEnvironment webHostEnvironment)
        {
            _employeeServices = employeeServices;
            _companyServices = companyServices;
            _positionServices = positionServices;
            _departamentServices = departamentServices;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index(EmployeeSearch obj)
        {
            var model = new EmployeeSearch();

            var employeeList = await _employeeServices.SeachEmployees(obj);
            model.employees = employeeList;

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var company = await _employeeServices.GetEmployeeById(id);
            return View(company);
        }


        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var model = new CreateEmployeeViewModel()
            {
                companies = await _companyServices.GetCompanies(),
                departments = await _departamentServices.GetDepartaments(),
                positions = await _positionServices.GetPositions()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateEmployeeViewModel form)
        {
            try
            {
                var result = await _employeeServices.CreateNewEmployee(form);

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
                var employee = await _employeeServices.GetEmployeeById(id);

                var model = new CreateEmployeeViewModel()
                {
                    id = employee.id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Patronymic = employee.Patronymic,
                    Adress = employee.Adress,
                    Phone = employee.Phone,
                    BirthDate = employee.BirthDate,
                    EntryDay = employee.EntryDay,
                    Salary = employee.Salary,
                    companies = await _companyServices.GetCompanies(),
                    departments = await _departamentServices.GetDepartaments(),
                    positions = await _positionServices.GetPositions()
                };

                if (employee == null)
                {
                    return NotFound();
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CreateEmployeeViewModel employeeView)
        {
            try
            {
                var result = await _employeeServices.UpadateEmployee(employeeView);
                return RedirectToAction(nameof(Index));

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
                var company = await _employeeServices.GetEmployeeById(id);

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
                var company = await _employeeServices.GetEmployeeById(id);

                if (company != null)
                {
                    await _employeeServices.DeleteEmployeeById(id);
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

        public async Task<FileResult> Download()
        {
            var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Files", "file.txt");

            await _employeeServices.FielRecordingAsync(filePath);
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            string fileName = "file.txt";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}
