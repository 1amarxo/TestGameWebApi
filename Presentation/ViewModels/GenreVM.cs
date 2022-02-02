using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class GenreVM
    {
        public string Name { get; set; }
    }
    public class GenreWithGamesVM
    {
        public string Name { get; set; }
        public List<string> GameNames { get; set; }
    }
}
