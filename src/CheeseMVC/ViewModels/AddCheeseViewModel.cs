using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }


        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must give your cheese a description")]
        public string Description { get; set; }

        //public Category { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public AddCheeseViewModel(IEnumerable<CheeseCategory> categories) {

            Categories = new List<SelectListItem>();

            //iterate over selectlistitem and add to it each categoryID & corresponding name of category
            foreach (CheeseCategory item in categories) {

                Categories.Add(new SelectListItem {
                    Value = item.ID.ToString(),
                    Text = item.Name
                });
            }
           // CheeseTypes.Add(new SelectListItem
            //{
               // Value = ((int)CheeseType.Soft).ToString(),
               // Text = CheeseType.Soft.ToString()
           // });

            //CheeseTypes.Add(new SelectListItem
            //{
               // Value = ((int)CheeseType.Fake).ToString(),
               // Text = CheeseType.Fake.ToString()
           // });

        }

        public AddCheeseViewModel()
        {

        }

       /* public AddCheeseViewModel(List<CheeseCategory> list)
        {
            this.list = list;
        }
        */
    }
}
