using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Services;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly GenreService genreService;
        public GenresController(GenreService genreService)
        {
            this.genreService = genreService;
        }

        /// <summary>
        ///   Add genre 
        /// </summary>
        /// <returns></returns>
        [HttpPost("add-genre")]
        public IActionResult AddGame([FromBody] GenreVM genre)
        {
            genreService.AddGenre(genre);
            return Ok();
        }



        /// <summary>
        ///   Get genre with Games by ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-genre-whith-games-by-id/{id}")]
        public IActionResult GetGenreWithGames(int id)
        {
           var genre= genreService.GetGenreWithGames(id);
            return Ok(genre);
        }


        /// <summary>
        ///   Get genre with Games by NAME
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-genre-whith-games-by-name/{name}")]
        public IActionResult GetGenreWithGames(string name)
        {
            var genre = genreService.GetGenreWithGames(name);
            return Ok(genre);
        }
        /// <summary>
        ///   Get all genre
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-genres")]
        public IActionResult GetAll()
        {
            var genres = genreService.GetAll();
            return Ok(genres);
        } 

    }
}
