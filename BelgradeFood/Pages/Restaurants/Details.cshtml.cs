using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BelgradeFood.Core;
using BelgradeFood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BelgradeFood
{
    public class DetailsModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;

        public Restaurant Restaurant { get; set; }
        [TempData]
        public string Message { get; set; }

        public DetailsModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {

            Restaurant = _restaurantData.GetByIdRestaurant(restaurantId);

            if(Restaurant is null) return RedirectToPage("./NotFound");

            return Page();
        }
    }
}