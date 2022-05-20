using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccess.Abstract;
using WebApi.DataAccess.Concrete;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class SeatsController : Controller
    {
        private ISeatRepository _seatRepository;
        public SeatsController()
        {
            _seatRepository = new SeatRepository();    
        }
        public IActionResult Index()
        {
            ViewBag.seats = this._seatRepository.GetAll();
            return View();
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var seat = this._seatRepository.GetById(id);
            if (seat != null)
            {
                return Ok(seat);
            }
            return BadRequest(new ErrorResult(seat.Id, "Seat is not found"));
        }
        public IActionResult Add(string message)
        {
            ViewBag.message = message;
            return View();
        }
        public IActionResult Update(int id, string message)
        {
            var seat = this._seatRepository.GetById(id);
            if (seat == null)
            {
                RedirectToAction("Index");
            }
            ViewBag.seat = seat;
            ViewBag.message = message;
            return View();
        }
        [HttpPost]
        public IActionResult Save(Seat seat)
        {
            string route = (seat.Id == 0) ? "Add" : "Update";
            if (seat.Id == 0)
            {
                this._seatRepository.Add(seat);
            }
            else
            {
                this._seatRepository.Update(seat);
            }
            return RedirectToAction("Index");
        }
        //[HttpDelete]
        public IActionResult Delete(int id)
        {
            this._seatRepository.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
