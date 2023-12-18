using DataManager.BLL.Interface;
using DataManager.BOL.Common;
using DataManager.BOL.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataManager.Ui.Controllers
{
    public class PayrollController : Controller
    {
        private readonly IPayrollServices _payrollServices;

        public PayrollController(IPayrollServices payrollServices)
        {
            _payrollServices = payrollServices;
        }

        public async Task<ActionResult> Index()
        {
            var companyCost = await _payrollServices.GetCompanyСostsData();
            var humanResourse = await _payrollServices.GetHumanResourseData();

            var model = new TabelInfoViewModel()
            {
                сosts = companyCost,
                humanResourses = humanResourse
            };

            return View(model);
        }
    }
}
