using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WebApi.DataAccess.Abstract;
using WebApi.DataAccess.Concrete;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class TicketsController : Controller
    {
        private ITicketRepository _ticketRepository;
        private IMovieRepository _movieRepository;
        private ISaloonRepository _saloonRepository;
        private ISeanseRepository _seanseRepository;
        private ISeatRepository _seatRepository;
        private IPriceRepository _priceRepository;
        public TicketsController()
        {
            _movieRepository = new MovieRepository();
            _seanseRepository = new SeanseRepository();
            _saloonRepository = new SaloonRepository();
            _seatRepository = new SeatRepository();
            _ticketRepository = new TicketRepository();
            _priceRepository = new PriceRepository();
        }
        public IActionResult Index()
        {
            ViewBag.tickets = this._ticketRepository.GetAllWithTimeSaloonSeatMovieandPrice();
            ViewBag.movies = this._movieRepository.GetAllWithTimeSaloonandPrice();
            return View();
        }
        public IActionResult TicketInformation()
        {
            return View();
        }
        public IActionResult Add(string message)
        {
            ViewBag.seanses = this._seanseRepository.GetAll();
            ViewBag.saloons = this._saloonRepository.GetAll();
            ViewBag.seats = this._seatRepository.GetAll();
            ViewBag.movies = this._movieRepository.GetAll();
            ViewBag.prices = this._priceRepository.GetAll();
            ViewBag.add = this._movieRepository.GetAllWithTimeSaloonandPrice();
            ViewBag.message = message;
            return View();
        }
        public IActionResult GetSeanse(int movieId)
        {
            var movie = this._movieRepository.GetById(movieId);
            var seanse = this._seanseRepository.GetById(movie.SeanseId);
            return Ok(seanse);
        }
        public IActionResult GetPrice(int movieId)
        {
            var movie = this._movieRepository.GetById(movieId);
            var price = this._priceRepository.GetById(movie.PriceId);
            return Ok(price);
        }
        public IActionResult GetSaloon(int movieId)
        {
            var movie = this._movieRepository.GetById(movieId);
            var saloon = this._saloonRepository.GetById(movie.SaloonId);
            return Ok(saloon);
        }
        public IActionResult Update(int id, string message)
        {
            var ticket = this._ticketRepository.GetById(id);
            if (ticket == null)
            {
                RedirectToAction("Index");
            }
            ViewBag.ticket = ticket;
            ViewBag.message = message;
            return View();
        }
        public IActionResult Delete(int id)
        {
            this._ticketRepository.DeleteById(id);
            return RedirectToAction("Index");
        }
        public IActionResult Save([Bind("Id", "SaloonId", "SeanseId", "MovieId", "SeatId", "PriceId", "EMailDetail")] Ticket ticket)
        {
            ViewBag.ticket = _ticketRepository.GetAll();
            ViewBag.seats = this._seatRepository.GetAll();
            string route = (ticket.Id == 0) ? "Add" : "Update";
            if (ticket.Id == 0)
            {
                this._ticketRepository.Add(ticket);
            }
            else
            {
                this._ticketRepository.Update(ticket);
            }
            if (ticket.SaloonId == 0)
            {
                return RedirectToAction(route, new ErrorResult(ticket.Id, "Please Select Saloon!"));
            }
            if (ticket.SeanseId == 0)
            {
                return RedirectToAction(route, new ErrorResult(ticket.Id, "Please Select Seanse!"));
            }
            if (ticket.MovieId == 0)
            {
                return RedirectToAction(route, new ErrorResult(ticket.Id, "Please Select Movie!"));
            }
            if (ticket.SeatId == 0)
            {
                return RedirectToAction(route, new ErrorResult(ticket.Id, "Please Select Seat!"));
            }
            if(ticket.EMailDetail==null)
            {
                return RedirectToAction(route, new ErrorResult(ticket.Id, "Please Enter EMail"));
            }
            if (ticket.PriceId == 0)
            {
                return RedirectToAction(route, new ErrorResult(ticket.Id, "Please Enter Price!"));
            }
            
            Seat seat = _seatRepository.GetById(ticket.SeatId);
            if (seat.Statue == false)
            {
                seat.Statue = true;
                _seatRepository.Update(seat);
                _ticketRepository.Update(ticket);
                return RedirectToAction("TicketInformation");
            }
            if (seat.Statue == true)
            {
                return RedirectToAction(route, new ErrorResult(ticket.Id, "Sorry, this seat is full!"));
            }
            return RedirectToAction("TicketInformation");
        }
    }
}
