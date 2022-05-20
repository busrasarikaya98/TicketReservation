using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccess.Abstract;
using WebApi.DataAccess.Concrete;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class PricesController : Controller
    {
        private IPriceRepository _priceRepository;
        public PricesController()
        {
            _priceRepository = new PriceRepository();
        }
        public IActionResult Index()
        {
            ViewBag.prices = this._priceRepository.GetAll();
            return View();
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var price = this._priceRepository.GetById(id);
            if (price != null)
            {
                return Ok(price);
            }
            return BadRequest(new ErrorResult(price.Id, "Price is not found"));
        }
        public IActionResult Add(string message)
        {
            ViewBag.message = message;
            return View();
        }
        public IActionResult Update(int id, string message)
        {
            var price = this._priceRepository.GetById(id);
            if (price == null)
            {
                RedirectToAction("Index");
            }
            ViewBag.price = price;
            ViewBag.message = message;
            return View();

        }
        [HttpPost]
        public IActionResult Save(Price price)
        {
            string route = (price.Id == 0) ? "Add" : "Update";
            if (price.Id == 0)
            {
                this._priceRepository.Add(price);
            }
            else
            {
                this._priceRepository.Update(price);
            }
            return RedirectToAction("Index");
        }
        //[HttpDelete]
        public IActionResult Delete(int id)
        {
            this._priceRepository.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
