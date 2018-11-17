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
        private readonly Stickynotes210Context _context;

        public BoardsController(Stickynotes210Context context)
        {
            _context = context;
        }

        // GET: api/Boards
        [HttpGet]
        public IEnumerable<Boards> GetBoards()
        {
            return _context.Boards;
        }

        // GET: api/Boards/5
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoards([FromRoute] int id)
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

            _context.Boards.Remove(boards);
            await _context.SaveChangesAsync();

            return Ok(boards);
        }

        private bool BoardsExists(int id)
        {
            return _context.Boards.Any(e => e.BoardId == id);
        }
    }
}