using AutoMapper;
using DTOs;
using Entities;
using EserKepenk.BLL.Managers.Concrete;
using EserKepenk.DAL.Context;
using EserKepenk.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EserKepenk.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private EserKepenkDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private int _rowNum = 1;

		public HomeController(ILogger<HomeController> logger, EserKepenkDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
        public IActionResult messages()
        {
            List<Guest> guests = _context.Guests.ToList();
            List<GuestViewModel> models = new List<GuestViewModel>();
            foreach (var item in guests)
            {
                GuestViewModel model = new GuestViewModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Description = item.Description;
                model.Phone = item.Phone;
                model.Email = item.Email;
                model.Surname = item.Surname;
                model.RowNum = _rowNum++;
                models.Add(model);
            }

            return View(models);
        }
    }
}
