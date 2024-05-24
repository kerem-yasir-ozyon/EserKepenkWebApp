using DTOs;
using Entities;
using EserKepenk.BLL.Managers.Concrete;
using EserKepenk.DAL.Context;
using EserKepenk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;

namespace EserKepenk.Controllers
{
    public class SliderController : Controller
    {
        private EserKepenkDbContext _context;
        int _rowNum = 1;
        public SliderController(EserKepenkDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Slider> sliderList = new List<Slider>();
            List<SliderViewModel> sliderViewModel = new List<SliderViewModel>();

            foreach (Slider slider in _context.Sliders.ToList())
            {
                SliderViewModel model = new SliderViewModel();
                model.Picture = slider.Picture;
                model.Id = slider.Id;
                model.IsActive = slider.IsActive;
                model.Title = slider.Title;
                model.Description = slider.Description;
                model.Picture = slider.Picture;
                model.Order = slider.Order;
                model.PictureFile = slider.PictureFile;
                model.Created = slider.Created;
                sliderViewModel.Add(model);
                model.RowNum = _rowNum++;

            }

            return View(sliderViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            SliderViewModel slider = new SliderViewModel();

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            for (int i = 1; i < 5; i++)
            {
                selectListItems.Add(new SelectListItem { Text = $"Sıra {i}", Value = i.ToString() });
            }
            ViewBag.OrderList = selectListItems;

            return View(slider);
        }
        [HttpPost]
        public IActionResult Create(SliderViewModel vm)
        {
            var dosyadakiFileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", vm.PictureFormFile.FileName);

            if (vm.PictureFormFile is not null && vm.Picture != dosyadakiFileName)
            {





                var konum = dosyadakiFileName;

                //Kaydetmek için bir akış ortamı oluşturalım
                var akisOrtami = new FileStream(konum, FileMode.Create);
                var memory = new MemoryStream();

                //Resmi kaydet
                vm.PictureFormFile.CopyTo(akisOrtami);
                vm.PictureFormFile.CopyTo(memory);

                Slider slider = new Slider();
                slider.Picture = vm.Picture;
                slider.IsActive = vm.IsActive;
                slider.Title = vm.Title;
                slider.Description = vm.Description;
                slider.Picture = vm.PictureFormFile.FileName;
                slider.PictureFile = vm.PictureFile;
                slider.Order = vm.Order;


                slider.PictureFile = memory.ToArray();

                _context.Sliders.Add(slider);
                _context.SaveChanges();

                akisOrtami.Dispose();
                memory.Dispose();

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Slider slider = _context.Sliders.AsNoTracking().FirstOrDefault(x => x.Id == id);

            SliderViewModel model = new SliderViewModel();
            model.Picture = slider.Picture;
            model.Id = slider.Id;
            model.IsActive = slider.IsActive;
            model.Title = slider.Title;
            model.Description = slider.Description;
            model.Picture = slider.Picture;
            model.Order = slider.Order;
            model.PictureFile = slider.PictureFile;
            model.Created = slider.Created;


            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(SliderViewModel model)
        {
            Slider slider = _context.Sliders.Find(model.Id);
            slider.Picture = model.Picture;
            slider.IsActive = model.IsActive;
            slider.Title = model.Title;
            slider.Description = model.Description;
            slider.Picture = model.Picture;
            slider.Order = model.Order;
            slider.PictureFile = model.PictureFile;
            slider.Created = model.Created;

            //_context.Entry(slider).State = EntityState.Deleted;
            _context.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Slider slider = _context.Sliders.Find(id);
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            for (int i = 1; i < 5; i++)
            {
                selectListItems.Add(new SelectListItem { Text = $"Sıra {i}", Value = i.ToString() });
            }
            ViewBag.OrderList = selectListItems;


            SliderEditViewModel model = new SliderEditViewModel();
            model.Picture = slider.Picture;
            model.IsActive = slider.IsActive;
            model.Title = slider.Title;
            model.Description = slider.Description;
            model.Picture = slider.Picture;
            model.Order = slider.Order;
            model.PictureFile = slider.PictureFile;
            model.Created = slider.Created;

            if (model.Picture == null)
            {
                model.Picture = slider.Picture;

            }


            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(SliderEditViewModel model)
        {

            if (model.PictureFormFile is null)
            {
                ModelState.Remove<SliderEditViewModel>(m => m.PictureFormFile);
            }


            ModelState.Remove<SliderEditViewModel>(m => m.RowNum);

            if (ModelState.IsValid)
            {
                Slider slider = _context.Sliders.Find(model.Id);
                var memory = new MemoryStream();

                if (model.PictureFormFile != null && model.PictureFormFile.Name != model.Picture)
                {
                    model.Picture = model.PictureFormFile.FileName;

                    

                    var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", model.PictureFormFile.FileName);

                    //Kaydetmek için bir akış ortamı oluşturalım
                    var akisOrtami = new FileStream(konum, FileMode.Create);


                    //Resmi kaydet
                    model.PictureFormFile.CopyTo(akisOrtami);
                    model.PictureFormFile.CopyTo(memory);

                    slider.PictureFile = memory.ToArray();
                    slider.Picture = model.Picture;

                    akisOrtami.Dispose();
                    memory.Dispose();
                }

                slider.IsActive = model.IsActive;
                slider.Title = model.Title;
                slider.Description = model.Description;
                slider.Order = model.Order;
                slider.Updated = DateTime.Now;

                _context.Update(slider);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
