using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodieApp.Models
{
    public class Restaurant
    {
        public Restaurant(int rank) //Constructor to set the rank of each restaurant - since the rank is read only.
        {
            Rank = rank;
        }
        [Required]
        public int Rank { get; }
        [Required]
        public string Name { get; set; }
        #nullable enable
        public string? FavDish { get; set; }
        #nullable disable
        [Required]
        public string Address { get; set; }
        #nullable enable
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "The phone number must be in this format: 555-555-5555")]
        public string? Phone { get; set; }
        public string? Website { get; set; } = "Coming soon.";
        #nullable disable

        public static Restaurant[] GetRestaurants() //Function to set values for each restaurant in the array, some values are commented out to show functionality of null handling.
        {
            Restaurant r1 = new Restaurant(1)
            {
                Name = "Tucanos",
                FavDish = "Full Churrasco",
                Address = "545 E University Pkwy, Orem, UT 84097",
                Phone = "(801) 224-4774",
                Website = "https://www.tucanos.com/"
            };
            Restaurant r2 = new Restaurant(2)
            {
                Name = "Texas Roadhouse",
                FavDish = "Texas Combo: Ribs and Chicken Critters",
                Address = "1265 S State St, Orem, UT 84097",
                Phone = "(801) 226-2742",
                Website = "https://www.texasroadhouse.com/"
            };
            Restaurant r3 = new Restaurant(3)
            {
                Name = "Brick Oven",
                /*FavDish = "Meat-A-Pizza",*/
                Address = "111 E 800 N, Provo, UT 84606",
                Phone = "(801) 224-4774",
                Website = "https://www.brickovenrestaurants.com/"
            };
            Restaurant r4 = new Restaurant(4)
            {
                Name = "Panda Express",
                FavDish = "Orange Chicken",
                Address = "1240 N University Ave, Provo, UT 84604",
                Phone = "(801) 818-0111"/*,*/
                /*Website = "https://www.pandaexpress.com/"*/
            };
            Restaurant r5 = new Restaurant(5)
            {
                Name = "Seven Brothers Burgers",
                FavDish = "Paniolo Burger",
                Address = "4801 N University Ave #220, Provo, UT 84604",
                Phone = "(385) 477-4220",
                Website = "http://www.sevenbrothersburgers.com/"
            };

            return new Restaurant[] { r1, r2, r3, r4, r5 };
        }
    }
}
