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


        [HttpPost("add-genre")]
        public IActionResult AddGame([FromBody] GenreVM genre)
        {
            genreService.AddGenre(genre);
            return Ok();
        }

        [HttpGet("get-genre-whith-games-by-id/{id}")]
        public IActionResult GetGenreWithGames(int id)
        {
           var genre= genreService.GetGenreWithGames(id);
            return Ok(genre);
        }

        [HttpGet("get-all-genres")]
        public IActionResult GetAll()
        {
            var genres = genreService.GetAll();
            return Ok(genres);
        } 

    }
}
