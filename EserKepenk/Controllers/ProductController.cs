using AutoMapper;
using DTOs;
using EserKepenk.BLL.Managers.Concrete;
using EserKepenk.DAL.Context;
using EserKepenk.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Security.AccessControl;
using System.Security.Cryptography;

namespace EserKepenk.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private ProductManager _productManager;
        private CategoryManager _categoryManager;
        private IMapper _mapper;
        private int _id = 1;
        public ProductController(ProductManager productManager, CategoryManager categoryManager)
        {
            _productManager = productManager;

            MapperConfiguration config = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductViewModel, ProductDto>().ForMember(x => x.Picture, y => y.MapFrom(z => (z.PictureFormFile == null)? z.Picture : z.PictureFormFile.FileName));
                config.CreateMap<ProductDto, ProductViewModel>().ForMember(x => x.Picture, y => y.MapFrom(z => z.Picture));

                config.CreateMap<ProductEditViewModel, ProductDto>().ForMember(x => x.Picture, y => y.MapFrom(z => (z.PictureFormFile == null) ? z.Picture : z.PictureFormFile.FileName));
                config.CreateMap<ProductDto, ProductEditViewModel>().ForMember(x => x.Picture, y => y.MapFrom(z => z.Picture));

                config.CreateMap<CategoryViewModel, CategoryDto>().ReverseMap();
                config.CreateMap<ProductEditViewModel, ProductViewModel>().ReverseMap();
            });
            _mapper = config.CreateMapper();

            _categoryManager = categoryManager;
        }
        public IActionResult Index()
        {
            List<ProductDto> productDtos = _productManager.GetAll().ToList();
            List<ProductViewModel> models = new List<ProductViewModel>();
            foreach (ProductDto dto in productDtos)
            {
                ProductViewModel model = new ProductViewModel();
                model = _mapper.Map<ProductViewModel>(dto);
                models.Add(model);
                model.RowNum = _id++;
            }

            return View(models);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ProductViewModel vm = new ProductViewModel();
            List<SelectListItem> categories = new List<SelectListItem>();
            if (_categoryManager.GetAll().ToList() == null)
            {
            ViewBag.ErrorMessage =  "Ürün ekleyebilmek için öncelikle kategori eklemelisiniz";
                return View(vm);
            }
            List<CategoryDto> categoryDto = _categoryManager.GetAll().ToList();



            categories.Add(new SelectListItem { Text = "Kategori seçiniz", Value = "-1", Selected = true });

            foreach (CategoryDto dto in categoryDto)
            {
                categories.Add(new SelectListItem { Text = dto.Name, Value = dto.Id.ToString() });
            }
            

          
            

            ViewBag.Categories = categories;

            return View(vm);

        }

        [HttpPost]
        public IActionResult Create(ProductViewModel vm)
        {
            var dosyadakiFileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", vm.PictureFormFile.FileName);

            if (vm.PictureFormFile is not null && vm.Picture != dosyadakiFileName )
            {
                var konum = dosyadakiFileName;

                //Kaydetmek için bir akış ortamı oluşturalım
                var akisOrtami = new FileStream(konum, FileMode.Create);
                var memory = new MemoryStream();

                //Resmi kaydet
                vm.PictureFormFile.CopyTo(akisOrtami);
                vm.PictureFormFile.CopyTo(memory);

                ProductDto dtoPr = _mapper.Map<ProductDto>(vm);
                dtoPr.PictureFile = memory.ToArray();

                _productManager.Add(dtoPr);

                akisOrtami.Dispose();
                memory.Dispose();

			return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ProductDto dto = _productManager.GetById(id);
            ProductViewModel vm = _mapper.Map<ProductViewModel>(dto);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Delete(ProductViewModel model)
        {
            ProductDto dto = _productManager.GetById(model.Id);
            var dosyadakiFileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", dto.Picture);

            if (_productManager.Delete(dto) > 0)
            {
                System.IO.File.Delete(dosyadakiFileName);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ProductDto dto = _productManager.GetById(id);

            var categoriesList =  _categoryManager.GetAll().ToList();
            
            List<SelectListItem> categories = new List<SelectListItem>();
            ViewBag.Categories = new SelectList(categoriesList.ToList(), "Id", "Name");


            ProductEditViewModel vm = _mapper.Map<ProductEditViewModel>(dto);

            if (vm.Picture == null)
            {
                vm.Picture = dto.Picture;
   
            }
            ViewBag.PicName = vm.Picture;

            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(ProductEditViewModel model)
        {

            if(model.PictureFormFile is null)
            {
                ModelState.Remove<ProductEditViewModel>(m => m.PictureFormFile);
            }
                       

            ModelState.Remove<ProductEditViewModel>(m => m.Category);
            ModelState.Remove<ProductEditViewModel>(m => m.RowNum);

            if (ModelState.IsValid)
            {
                ProductDto dtoPr = _mapper.Map<ProductDto>(model);


                ProductDto dtoPrOrj = _productManager.GetById(model.Id);


                dtoPr.PictureFile = dtoPrOrj.PictureFile;

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
                    dtoPr.PictureFile = memory.ToArray();

					akisOrtami.Dispose();
					memory.Dispose();
				}
                 
                _productManager.Update(dtoPr);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            ProductDto Dto = _productManager.GetById(id);
            ProductViewModel vm = _mapper.Map<ProductViewModel>(Dto);

            return View(vm);
        }


    }
}
