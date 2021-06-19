
using AutoMapper;
using Olympiads.BLL.DTO;
using Olympiads.BLL.Interfaces;
using Olympiads.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Olympiads.WEB.Controllers
{
    public class CategoriesController : Controller
    {
        ICategoryService CategoryService { get; set; }
        public CategoriesController(ICategoryService service)
        {
            CategoryService = service;
        }
        public ActionResult RenderCategoryFilters()
        {
            var categories = CategoryService.GetAll();
            var mapper = new MapperConfiguration(x => x.CreateMap<CategoryDTO, CategoryVM>()).CreateMapper();

            return PartialView("CategoryFiltersPartial", mapper.Map<IEnumerable<CategoryDTO>, IEnumerable<CategoryVM>>(categories));
        }
    }
}