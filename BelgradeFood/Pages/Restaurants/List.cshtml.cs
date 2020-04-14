using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BelgradeFood.Core;
using BelgradeFood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace BelgradeFood
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IRestaurantData _restaurantData;


        #region public property
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public string Message { get; set; }

        public IEnumerable<Restaurant> Restaurants { get; set; }
        #endregion



        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            _config = config;
            _restaurantData = restaurantData;
        }
        public void OnGet()
        {
            
            Restaurants = _restaurantData.GetRestaurantsByName(SearchTerm);

            Message = _config["Message"];
        }
    }
}