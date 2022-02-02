using Core.Entities;
using Infrastructure;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class GameService
    {
        private readonly GamesDbContext context;
        public GameService(GamesDbContext context)
        {
            this.context = context;
        }

        public void AddGameWithGenres(GameVM gameVM)
        {
            var game = new Game()
            {
                Name = gameVM.Name,
                Producer = gameVM.Producer
                
            };
            context.Games.Add(game);
            context.SaveChanges();

            foreach(var id in gameVM.GenreId)
            {
                var game_genre = new Game_Genre()
                {
                    GameId = game.Id,
                    GenreId = id
                };
                context.Game_Genre.Add(game_genre);
                context.SaveChanges();
            }
        }

        public GameWithGenresVM GetById(int id)
        {
            var game = context.Games.Where(n=>n.Id==id).Select(gameVM => new GameWithGenresVM()
            {

                Name = gameVM.Name,
                Producer = gameVM.Producer,
                GenreName=gameVM.Game_Genres.Select(n=> n.Genre.Name).ToList()
            }).FirstOrDefault();

            return game;
        }

        public List<Game> GetAll()
        {
            
            return context.Games.ToList(); 
        }

        public Game Update(int id,Game game)
        {
            context.Games.Update(game);
            context.SaveChanges();

            return game;
        }


        public void Delete(int id)
        {
            var game = context.Games.FirstOrDefault(p => p.Id == id);
            context.Games.Remove(game);
            context.SaveChanges();
           

        }
    }
}
