using AutoMapper;
using DTOs;
using Entities;
using EserKepenk.BLL.Managers.Concrete;
using EserKepenk.DAL.Context;
using EserKepenkFront.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Security.Cryptography;

namespace EserKepenkFront.Controllers
{
    //[Route("Anasayfa")]
    public class HomeController : Controller
    {
        private CategoryManager _categoryManager;
        private ProductManager _productManager;
        private IMapper _mapper;
        private int _id = 1;
        private EserKepenkDbContext _context;

        private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger, CategoryManager categoryManager, ProductManager productManager, EserKepenkDbContext context)
		{
			_logger = logger;
			_categoryManager = categoryManager;


			MapperConfiguration config = new MapperConfiguration(config =>
			{
				config.CreateMap<CategoryViewModel, CategoryDto>().ForMember(x => x.Products, y => y.MapFrom(z => z.Products));
				config.CreateMap<CategoryDto, CategoryViewModel>().ForMember(x => x.Products, y => y.MapFrom(z => z.Products));
				config.CreateMap<ProductViewModel, ProductDto>().ReverseMap();
			});
			_mapper = config.CreateMapper();
			_productManager = productManager;
			_context = context;
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
            //PageData["kategoriler"] = models;

            List<Slider> sliders =  _context.Sliders.Where(s => s.IsActive).OrderBy(x=> x.Order).ThenBy(x=> x.Created).Take(5).ToList();
            List<SliderViewModel> sliderModels = new List<SliderViewModel>();
            foreach (Slider slider in sliders)
            {
                SliderViewModel model = new SliderViewModel();
                model.Title = slider.Title;
                model.Description = slider.Description;
                model.PictureFile = slider.PictureFile;
                model.Created = slider.Created;

                sliderModels.Add(model);
            }
            ViewBag.Sliders = sliderModels;
            ViewBag.SliderCount = sliderModels.Count();

            return View(models);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


		[HttpGet]
		//[Route("Anasayfa/Kategoriler")]
		public ActionResult GenericCategory(int id)
		{
			CategoryDto dto = _categoryManager.GetById(id);
			CategoryViewModel vm = _mapper.Map<CategoryViewModel>(dto);

			//if (dto.Products != null)
			//{
			//    ViewBag.list1 = dto.Products.ToList();
			//}

			return View(vm);
		}

        public ActionResult RenderImage(int id)
        {
            ProductDto product = _productManager.GetByIdAsync(id);

            string[] pictureInfo = product.Picture.Split('.');
            byte[] byteData = product.PictureFile;

            return File(byteData, "image/" + pictureInfo[1]);
        }

		[HttpPost]
		public ActionResult GenericCategory(CategoryViewModel model)
		{
			if (model.Products != null)
			{
				ViewBag.CatProds = model.Products;
			}

			return View(model);
		}

		//[Route("Anasayfa/Hakkimizda")]
		public IActionResult About()
        {
            List<CategoryDto> dtos = _categoryManager.GetAll().ToList();
            List<CategoryViewModel> edit = new List<CategoryViewModel>();
            foreach (CategoryDto dto in dtos)
            {
                CategoryViewModel model = new CategoryViewModel();
                model = _mapper.Map<CategoryViewModel>(dto);
                edit.Add(model);
            }
            return View(edit);

        }
        [HttpGet]
		//[Route("Anasayfa/Iletisim")]
		public IActionResult Contact()
        {
            GuestViewModel vm = new GuestViewModel();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Contact(GuestViewModel model)
        {
            Guest guest = new Guest();

            guest.Id = model.Id;
            guest.Name = model.Name;
            guest.Surname = model.Surname;
            guest.Description = model.Description;
            guest.Phone = model.Phone;
            guest.Email = model.Email;

			_context.Guests.Add(guest);
	    	 _context.SaveChanges();
			return Json(new {isSuccess = true, record = new { id= guest.Id } });
        }
	}
}
