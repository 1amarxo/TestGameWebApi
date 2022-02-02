using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class GameVM
    {
        public string Name { get; set; }
        public string Producer { get; set; }

        public List<int> GenreId{get;set;}
    }

    public class GameWithGenresVM
    {
        public string Name { get; set; }
        public string Producer { get; set; }

        public List<string> GenreName { get; set; }
    }
}
