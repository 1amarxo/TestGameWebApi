using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Game_Genre> Game_Genres { get; set; }
    }
}
