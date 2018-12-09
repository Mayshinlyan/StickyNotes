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
    public class UserBoardsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserBoardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserBoards
        [HttpGet]
        public IEnumerable<UserBoards> GetUserBoards()
        {
            return _context.UserBoards;
        }

        // GET: api/UserBoards/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserBoards([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userBoards = await _context.UserBoards.FindAsync(id);

            if (userBoards == null)
            {
                return NotFound();
            }

            return Ok(userBoards);
        }

        // PUT: api/UserBoards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserBoards([FromRoute] string id, [FromBody] UserBoards userBoards)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userBoards.Id)
            {
                return BadRequest();
            }

            _context.Entry(userBoards).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserBoardsExists(id))
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

        // POST: api/UserBoards
        [HttpPost]
        public async Task<IActionResult> PostUserBoards([FromBody] UserBoards userBoards)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserBoards.Add(userBoards);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserBoardsExists(userBoards.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserBoards", new { id = userBoards.Id }, userBoards);
        }

        // DELETE: api/UserBoards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserBoards([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userBoards = await _context.UserBoards.FindAsync(id);
            if (userBoards == null)
            {
                return NotFound();
            }

            _context.UserBoards.Remove(userBoards);
            await _context.SaveChangesAsync();

            return Ok(userBoards);
        }

        private bool UserBoardsExists(string id)
        {
            return _context.UserBoards.Any(e => e.Id == id);
        }
    }
}