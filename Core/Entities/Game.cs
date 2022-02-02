using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }

        public List<Game_Genre> Game_Genres { get; set; }
    }
}
