using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.Data;
using CheeseMVC.ViewModels;




// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

            // GET: /<controller>/
            public IActionResult Index()
            {
                IList<CheeseCategory> theCategory = context.Categories.ToList();
                return View(theCategory);
            }

        //adding category of cheeses to render form 
        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            return View(addCategoryViewModel);
        }

        //adding category of cheeses to retrieve data from form

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new cheese to my existing cheeses
                CheeseCategory newCategory = new CheeseCategory
                {
                    Name = addCategoryViewModel.Name
                    //Description = addCategoryViewModel.Description,
                    //Type = addCategoryViewModel.Type
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/Category");
            }

            return View(addCategoryViewModel);
        }


    }

    
}
