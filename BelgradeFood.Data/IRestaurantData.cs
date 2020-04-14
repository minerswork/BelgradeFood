using BelgradeFood.Core;
using System.Linq;
using System;
using System.Collections.Generic;

namespace BelgradeFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string restourantName);
        Restaurant GetByIdRestaurant(int restaurantId);
        Restaurant UpdateRestaurant(Restaurant restaurant);
        Restaurant AddRestaurant(Restaurant restaurant);

        int Commit();


    }

    public class InMemoryRestauranData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestauranData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{ Id=1,Name="marco`s",Location="Belgrade",Cuisine=CuisineType.Mexican},
                new Restaurant{ Id=2,Name="Tegla Bar",Location="Belgrade",Cuisine=CuisineType.Italian},
                new Restaurant{ Id=3,Name="Our Bar",Location="Belgrade",Cuisine=CuisineType.Indian},
                new Restaurant{ Id=4,Name="Berliner",Location="Belgrade",Cuisine=CuisineType.None},
            };
        }

        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(res => res.Id) + 1;

            return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant GetByIdRestaurant(int restaurantId)
        {
            return restaurants.FirstOrDefault(res => res.Id == restaurantId);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string restaurantName = null)
        {
            return from res in restaurants
                   where string.IsNullOrEmpty(restaurantName) || res.Name.StartsWith(restaurantName)
                   orderby res.Name
                   select res;
        }

        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            var updateres = restaurants.FirstOrDefault(res => res.Id == restaurant.Id);

            if(restaurant != null)
            {
                updateres.Name = restaurant.Name;
                updateres.Location = restaurant.Location;
                updateres.Cuisine = restaurant.Cuisine;
            }


            return restaurant;
        }



    }
}
