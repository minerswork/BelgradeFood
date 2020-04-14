using System.ComponentModel.DataAnnotations;

namespace BelgradeFood.Core
{
    public enum CuisineType { None,Mexican,Indian,Italian }

    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        [StringLength (50)]
        public string Name { get; set; }
        [Required]
        [StringLength(150)]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }

    }


}
