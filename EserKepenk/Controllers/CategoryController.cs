using AutoMapper;
using DTOs;
using Entities;
using EserKepenk.BLL.Managers.Concrete;
using EserKepenk.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EserKepenk.Controllers
{
     [Authorize]
    public class CategoryController : Controller
    {
        private CategoryManager _categoryManager;
        private ProductManager _productManager;
        private IMapper _mapper;
        private int _id = 1;
        public CategoryController(CategoryManager categoryManager, ProductManager productManager)
        {
            _categoryManager = categoryManager;
            _productManager = productManager;
            MapperConfiguration config = new MapperConfiguration(config =>
            {
                config.CreateMap<CategoryViewModel, CategoryDto>().ForMember(x => x.Products, y => y.MapFrom(z => z.Products));
                config.CreateMap<CategoryDto, CategoryViewModel>().ForMember(x => x.Products, y => y.MapFrom(z => z.Products));
                config.CreateMap<ProductViewModel, ProductDto>().ReverseMap();
            });
            _mapper = config.CreateMapper();
        }

        public IActionResult Index()
        {
            List<CategoryDto> productDtos = _categoryManager.GetAll().ToList();
            List<CategoryViewModel> models = new List<CategoryViewModel>();
            foreach (CategoryDto dto in _categoryManager.GetAll().ToList())
            {
                CategoryViewModel model = new CategoryViewModel();
                model = _mapper.Map<CategoryViewModel>(dto);
               
                models.Add(model);
                model.RowNum = _id++;
            }

            return View(models);
        }
 

        [HttpGet]
        public IActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel vm)
        {
            CategoryDto dto = _mapper.Map<CategoryDto>(vm);
            _categoryManager.Add(dto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            CategoryDto dto = _categoryManager.GetById(id);
            CategoryViewModel vm = _mapper.Map<CategoryViewModel>(dto);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Delete(CategoryViewModel model)
        {
            CategoryDto dto = _mapper.Map<CategoryDto>(model);
            _categoryManager.Delete(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CategoryDto dto = _categoryManager.GetById(id);
            CategoryViewModel vm = _mapper.Map<CategoryViewModel>(dto);

            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                CategoryDto dtoCr = _mapper.Map<CategoryDto>(model);
                _categoryManager.Update(dtoCr);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //public IActionResult Detail(int id)
        //{
        //    ViewBag.Category = _categoryManager.GetById(id);


        //    List<ProductDto> productDtos = new List<ProductDto>();
        //    List<ProductViewModel> viewModels = new List<ProductViewModel>();
        //    productDtos = _productManager.GetAll().Where(x => x.CategoryId == id).ToList();
        //    foreach (var Dto in productDtos)
        //    {

        //        ProductViewModel productVm = _mapper.Map<ProductViewModel>(Dto);
        //        viewModels.Add(productVm);

        //    }
        //    return View(viewModels);
        //}

        public IActionResult Detail(int id)
        {
            CategoryDto categoryDto = _categoryManager.GetById(id);
            var vm = _mapper.Map<CategoryViewModel>(categoryDto);
            if (categoryDto.Products != null)
            {
                ViewBag.list1 = categoryDto.Products.ToList();
            }
            

            

            //List<ProductViewModel> models = new List<ProductViewModel>();
            //List<ProductDto> dtoList = _productManager.GetAll().Where(x=> x.CategoryId == id).ToList();

            //foreach (ProductDto item in dtoList)
            //{
            //    ProductViewModel model = new ProductViewModel();
            //    model = _mapper.Map<ProductViewModel>(item);
            //    models.Add(model);
            //    model.RowNum = _id++;
            //}
            //ViewBag.models = models;
            return View(vm);
        }



    }
}
