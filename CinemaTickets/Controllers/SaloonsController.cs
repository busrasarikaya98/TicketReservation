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
    public class SaloonsController : Controller
    {
        private ISaloonRepository _saloonRepository;
        public SaloonsController()
        {
            _saloonRepository = new SaloonRepository();
        }
        public IActionResult Index()
        {
            ViewBag.saloons = this._saloonRepository.GetAll();
            return View();
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var saloon = this._saloonRepository.GetById(id);
            if (saloon != null)
            {
                return Ok(saloon);
            }
            return BadRequest(new ErrorResult(saloon.Id, "Saloon is not found"));
        }
        public IActionResult Add(string message)
        {
            ViewBag.message = message;
            return View();
        }
        public IActionResult Update(int id, string message)
        {
            var saloon = this._saloonRepository.GetById(id);
            if (saloon == null)
            {
                RedirectToAction("Index");
            }
            ViewBag.saloon = saloon;
            ViewBag.message = message;
            return View();

        }
        [HttpPost]
        public IActionResult Save(Saloon saloon)
        {
            string route = (saloon.Id == 0) ? "Add" : "Update";
            if (saloon.Name == null)
            {
                return BadRequest(new ErrorResult(saloon.Id, "Please Enter Name"));
            }
            if (saloon.Id == 0)
            {
                this._saloonRepository.Add(saloon);
            }
            else
            {
                this._saloonRepository.Update(saloon);
            }
            return RedirectToAction("Index");
        }
        //[HttpDelete]
        public IActionResult Delete(int id)
        {
            this._saloonRepository.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
