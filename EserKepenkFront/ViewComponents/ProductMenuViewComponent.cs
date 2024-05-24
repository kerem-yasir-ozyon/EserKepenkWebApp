using DTOs;
using EserKepenk.BLL.Managers.Concrete;
using EserKepenk.DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace EserKepenkFront.ViewComponents
{
	public class ProductMenuViewComponent : ViewComponent
	{
		private CategoryManager _categoryManager;

		public ProductMenuViewComponent(CategoryManager categoryManager)
		{
			_categoryManager = categoryManager;
		}

		public  IViewComponentResult Invoke()
		{
			List<CategoryDto> model = _categoryManager.GetAll().ToList();

			return View(model);
		}
	}
}
