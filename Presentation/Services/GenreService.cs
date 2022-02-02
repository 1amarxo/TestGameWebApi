using Core.Entities;
using Infrastructure;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class GenreService
    {
        private readonly GamesDbContext context;
        public GenreService(GamesDbContext context)
        {
            this.context = context;
        }

        public void AddGenre(GenreVM genreVM)
        {
            var genre = new Genre()
            {
                Name = genreVM.Name
            };
            context.Genres.Add(genre);
            context.SaveChanges();

        }


        public GenreWithGamesVM GetGenreWithGames(int genreId)
        {
            var genre = context.Genres.Where(g => g.Id == genreId).Select(g => new GenreWithGamesVM()
            {
                Name=g.Name,
                GameNames=g.Game_Genres.Select(g=>g.Game.Name).ToList()
            }).FirstOrDefault();


            return genre;
        }

        public List<Genre> GetAll()
        {
            return context.Genres.ToList();
        }

        public List<GenreWithGamesVM> GetGenreWithGames(string name)
        {

            var genre = context.Genres.Where(g => g.Name == name).Select(g => new GenreWithGamesVM()
            {
                Name = g.Name,
                GameNames = g.Game_Genres.Select(g => g.Game.Name).ToList()
            }).ToList();


            return genre;

        }
    }
}
