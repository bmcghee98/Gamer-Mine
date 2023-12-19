using IGDB;

namespace VideoGameDatabase.Models
{
    public class CardModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }
        public string Storyline { get; set; }
        public string Genres { get; set; }
        //public DateTime ReleaseDate { get; set; }
        //public string Developer { get; set; }
        //public string Category { get; set; }
    }
}
