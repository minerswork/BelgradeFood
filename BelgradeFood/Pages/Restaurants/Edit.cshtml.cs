using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BelgradeFood.Core;
using BelgradeFood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BelgradeFood
{
    public class EditModel : PageModel
    {
        //asp-items="Html.GetEnumSelectList<BelgradeFood.Core.CuisineType>()

        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _helper;

        public IEnumerable<SelectListItem> Cusines { get; set; }

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper helper)
        {
            _restaurantData = restaurantData;
            _helper = helper;
        }

        public IActionResult OnGet(int? restaurantId)
        {
            Cusines = _helper.GetEnumSelectList<CuisineType>();
            if(restaurantId.HasValue)
            {
                Restaurant = _restaurantData.GetByIdRestaurant(restaurantId.Value);
                if(Restaurant is null)
                {
                    RedirectToPage("./NotFound");
                }
            }
            else
            {
                Restaurant = new Restaurant();
            }
            

            return Page();

        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {

                Cusines = _helper.GetEnumSelectList<CuisineType>();
                return Page();
            }


            if(Restaurant.Id>0)
            {
                _restaurantData.UpdateRestaurant(Restaurant);
            }
            else
            {
                _restaurantData.AddRestaurant(Restaurant);
            }

            TempData["Message"] = "Restaurant saved successfully";
            _restaurantData.Commit();
            return RedirectToPage("./Details", new { restaurantId = Restaurant.Id });

        }
    }
}