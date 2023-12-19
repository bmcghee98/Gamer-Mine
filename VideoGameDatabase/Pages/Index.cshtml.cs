using IGDB.Models;
using IGDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoGameDatabase.Models;
using VideoGameDatabase.Services;

namespace VideoGameDatabase.Pages
{
    public class IndexModel : PageModel
    {
       
        public string Message { get; set; }
        public List<CardModel> Cards { get; set; }
        public string[] Themes
        {
            get { return new string[] { "Fantasy", "Thriller", "Action", "Horror", "Survival", 
                "Stealth", "Sandbox", "Open World", "Warfare", "Kids" }; }
            set { Themes = new string[]{"Fantasy", "Thriller", "Action", "Horror", "Survival", 
                "Stealth", "Sandbox", "Open World", "Warfare", "Kids"}; }
        }
        private readonly CardService cardService;

        public IndexModel(CardService service)
        {
            Cards = new List<CardModel>();
            cardService = service;
        }

        public async Task OnGetAsync()
        {
            Cards = await cardService.FetchCardsAsync();
        }
    }
}