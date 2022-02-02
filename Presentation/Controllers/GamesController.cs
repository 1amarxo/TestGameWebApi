using Core.Entities;
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
    public class GamesController : ControllerBase
    {
        private readonly GameService gameService;
        public GamesController(GameService gameService)
        {
            this.gameService = gameService;
        } 
        
        /// <summary>
        ///    Create games
        /// </summary>
        /// <returns></returns>

        [HttpPost("add-game-with-genres")]
        public IActionResult AddGame([FromBody] GameVM game)
        {
            gameService.AddGameWithGenres(game);
            return Ok();
        }


        /// <summary>
        ///    Get games by id  
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-game-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GetById(int id)
        {
            var game = gameService.GetById(id);
            return Ok(game);
        }

        /// <summary>
        ///    Get all games 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Game>> Getall()
        {
            var game = gameService.GetAll();
            return Ok(game);
        }

        /// <summary>
        ///    Update games
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("update-game/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Game> Update(int id, Game game)
        {
            var gameUpdate = gameService.Update(id,game);
            return Ok(gameUpdate);
        }

        /// <summary>
        ///    Delete games
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete-game/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Delete(int id)
        {
            gameService.Delete(id);
            return NoContent();
        }
    }
}
