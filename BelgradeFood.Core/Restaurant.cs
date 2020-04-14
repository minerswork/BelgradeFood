namespace BelgradeFood.Core
{
    public enum CuisineType { None,Mexican,Indian,Italian }

    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }

    }


}
