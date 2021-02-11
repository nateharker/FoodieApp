using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodieApp.Models
{
    public class Suggestion
    {
        #nullable enable
        public string? UserName { get; set; }
        #nullable disable
        [Required(ErrorMessage = "The Restaurant Name field is required")]
        public string Name { get; set; }
        #nullable enable
        public string? FavDish { get; set; }
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "The phone number must be in this format: 555-555-5555")]
        public string? Phone { get; set; }
        #nullable disable

        private static List<Suggestion> suggestions = new List<Suggestion>();

        public static IEnumerable<Suggestion> Suggestions => suggestions;

        public static void AddSuggestion(Suggestion suggestion) //Since values are gathered from a form, this function will insert default values if input is left blank on optional fields, then add the object to the list
        {
            if(suggestion.UserName is null)
            {
                suggestion.UserName = "Anonymous";
            }
            if (suggestion.FavDish is null)
            {
                suggestion.FavDish = "It's all tasty!";
            }
            suggestions.Add(suggestion);
        }
    }
}
