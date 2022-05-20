using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataAccess.Abstract;
using WebApi.DataAccess.Concrete;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class SeansesController : Controller
    {
        private ISeanseRepository _seanseRepository;
        public SeansesController()
        {
            _seanseRepository = new SeanseRepository();
        }
        public IActionResult Index()
        {
            ViewBag.seanses = this._seanseRepository.GetAll();
            return View();
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var seanse = this._seanseRepository.GetById(id);
            if (seanse != null)
            {
                return Ok(seanse);
            }
            return BadRequest(new ErrorResult(seanse.Id, "Seanse is not found"));
        }
        public IActionResult Add(string message)
        {
            ViewBag.message = message;
            return View();
        }
        public IActionResult Update(int id, string message)
        {
            var movietime = this._seanseRepository.GetById(id);
            if (movietime == null)
            {
                RedirectToAction("Index");
            }
            ViewBag.movietime = movietime;
            ViewBag.message = message;
            return View();
        }
        [HttpPost]
        public IActionResult Save(Seanse seanse)
        {
            string route = (seanse.Id == 0) ? "Add" : "Update";
            if (seanse.Id == 0)
            {
                this._seanseRepository.Add(seanse);
            }
            else
            {
                this._seanseRepository.Update(seanse);
            }
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public IActionResult DeleteById(Seanse seanse)
        {
            this._seanseRepository.DeleteById(seanse.Id);
            return Ok(seanse);
        }
    }
}
