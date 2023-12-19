using IGDB.Models;
using IGDB;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using VideoGameDatabase.Models;

namespace VideoGameDatabase.Services
{
    public class CardService
    {
        private readonly IConfiguration _configuration;
        public List<CardModel> Cards { get; set; } 
        IGDBClient _api;

        public CardService(IConfiguration configuration)
        {
            _configuration = configuration;
            Cards = new List<CardModel>();
            _api = new IGDBClient(
                _configuration["Connection:IGDB_CLIENT_ID"],
                _configuration["Connection:IGDB_CLIENT_SECRET"]
            );
        }

        public async Task<List<CardModel>> FetchCardsAsync()
        {
            // Fetch cards and append to this.Cards
            var gameQueryResult = await _api.QueryAsync<Game>(
                IGDBClient.Endpoints.Games,
                query: "fields id,name,summary,storyline,genres.name,artworks.image_id; limit 60;"
            );


            foreach (var game in gameQueryResult)
            {
                if (game.Artworks != null && game.Artworks.Values.Any())
                {
                    var artworkImageId = game.Artworks.Values.First().ImageId;
                    var genreNames = game.Genres?.Values.Select(genre => genre.Name)?.ToList() ?? new List<string>();
                    var genres = string.Join(", ", genreNames);
                    var card = new CardModel
                    {
                        Id = (int)game.Id,
                        Name = game.Name,
                        Summary = game.Summary,
                        Storyline = game.Storyline,
                        ImageUrl = IGDB.ImageHelper.GetImageUrl(imageId: artworkImageId, size: ImageSize.HD720, retina: false),
                        Genres = genres
                        // Set other properties as needed
                    };
                    this.Cards.Add(card);
                }
            }

            return this.Cards;
        }
    }
  





}
