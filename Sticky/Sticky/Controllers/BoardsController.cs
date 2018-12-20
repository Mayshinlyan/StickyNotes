using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sticky.Data;
using Sticky.Models;

namespace Sticky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BoardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Boards
        /// <summary>
        /// Gets all boards
        /// </summary>
        /// <returns> All boards </returns>
        [HttpGet]
        public IEnumerable<Boards> GetBoards()
        {
            return _context.Boards;
        }

        // GET: api/Boards/5
        /// <summary>
        /// Gets a specific board
        /// </summary>
        /// <param name="id"> The int representing the id of the board to get </param>
        /// <returns> The board if it is found. An appropriate message otherwise </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoards([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var boards = await _context.Boards.FindAsync(id);

            if (boards == null)
            {
                return NotFound();
            }
            _context.Entry(boards).Collection(p => p.Notes).Load();
            return Ok(boards);
        }

        // PUT: api/Boards/5
        /// <summary>
        /// Updates a board
        /// </summary>
        /// <param name="id"> The id of the board that is being updated </param>
        /// <param name="boards"> The model of the board to be updated </param>
        /// <returns> NoContent() if successful, an appropriate message otherwise </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoards([FromRoute] int id, [FromBody] Boards boards)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != boards.BoardId)
            {
                return BadRequest();
            }

            _context.Entry(boards).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Boards
        /// <summary>
        /// Creates a New Board. Increments Id to be one greater than the current number of boards
        /// </summary>
        /// <param name="boards"> Some information about a board. Realistically, none of it will be used. </param>
        /// <returns> A new board JSON object. </returns>
        [HttpPost]
        public async Task<IActionResult> PostBoards([FromBody] Boards boards)
        {
            boards.BoardId = _context.Boards.Count() + 1;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Boards.Add(boards);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BoardsExists(boards.BoardId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBoards", new { id = boards.BoardId }, boards);
        }

        // DELETE: api/Boards/5
        /// <summary>
        /// Altered to always return NoContent
        /// </summary>
        /// <param name="id"> The id of the board some misguided soul wants to delete. </param>
        /// <returns> NoContent() </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoards([FromRoute] int id)
        {
            return NoContent();
        }

        private bool BoardsExists(int id)
        {
            return _context.Boards.Any(e => e.BoardId == id);
        }
    }
}