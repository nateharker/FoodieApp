using FoodieApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FoodieApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<string> restaurantList = new List<string>();
            foreach (Restaurant r in Restaurant.GetRestaurants()) /*Iterates through all the restaurants in the array populated in the model*/
            {
                #nullable enable
                string? favDish = r.FavDish ?? "It's all tasty!"; /*Checks each FavDish property to see if it's null; if it is, it's assigned a default value*/
                #nullable disable
                /*if statement to avoid creating a clickable link in the view if the restaurant doesn't have a website and the property is set to the default "Coming soon."*/
                if (r.Website == "Coming soon.")
                {
                /*Restaurants are added one by one to the list and formatted with line breaks, special styling for the first line, and clickable links for the website*/
                    restaurantList.Add($"<span class=\"first-line\">#{r.Rank}: {r.Name}</span><br/>Favorite Dish: {favDish}<br/>Address: {r.Address}<br/>Phone Number: {r.Phone}<br/>Website: {r.Website}<br/>");
                }
                else
                {
                    restaurantList.Add($"<span class=\"first-line\">#{r.Rank}: {r.Name}</span><br/>Favorite Dish: {favDish}<br/>Address: {r.Address}<br/>Phone Number: {r.Phone}<br/>Website: <a href=\"{r.Website}\">{r.Website}</a><br/>");
                }
            }
            return View(restaurantList);

        }
        [HttpGet("Suggest")]
        public IActionResult SuggestForm()
        {
            return View();
        }

        [HttpPost("Suggest")]
        public IActionResult SuggestForm(Suggestion suggestion)
        {
            if(ModelState.IsValid) /*If user submission meets all requirements set in the model, the object is added to the list, and user is redirected to a confirmation page*/
            {
                Suggestion.AddSuggestion(suggestion);
                Response.Redirect("Confirmation");
            }
            return View();
        }

        [HttpGet("Confirmation")]
        public IActionResult SuggestConfirm()
        {
            return View();
        }

        [HttpGet("Suggestion-List")]
        public IActionResult SuggestList()
        {
            return View(Suggestion.Suggestions);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
