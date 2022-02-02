using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Game_Genre
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
