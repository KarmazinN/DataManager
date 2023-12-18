using DataManager.BLL.Interface;
using DataManager.BOL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataManager.Ui.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionServices _positionServices;

        public PositionController(IPositionServices positionServices)
        {
            _positionServices = positionServices;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var companies = await _positionServices.GetPositions();
            return View(companies);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var company = await _positionServices.GetPositionsById(id);
            return View(company);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Position formData)
        {
            try
            {
                var result = await _positionServices.CreateNewPosition(formData);

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
                var company = await _positionServices.GetPositionsById(id);

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
        public async Task<ActionResult> Edit(Position formData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _positionServices.UpadatePosition(formData);
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
                var company = await _positionServices.GetPositionsById(id);

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
                var company = await _positionServices.GetPositionsById(id);

                if (company != null)
                {
                    await _positionServices.DeletePositionById(id);
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
