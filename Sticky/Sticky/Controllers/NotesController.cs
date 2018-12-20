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
    public class NotesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Notes
        /// <summary>
        /// Gets all notes
        /// </summary>
        /// <returns> JSON of every note. </returns>
        [HttpGet]
        public IEnumerable<Notes> GetNotes()
        {
            return _context.Notes;
        }

        // GET: api/Notes/5
        /// <summary>
        /// Gets a note
        /// </summary>
        /// <param name="id"> the id of the note</param>
        /// <returns> If all goes well, then the note </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notes = await _context.Notes.FindAsync(id);

            if (notes == null)
            {
                return NotFound();
            }

            return Ok(notes);
        }

        // PUT: api/Notes/5
        /// <summary>
        /// Updates a note
        /// </summary>
        /// <param name="id"> The int representing id </param>
        /// <param name="notes"> The Note to be updated </param>
        /// <returns> Hopefully NoContent(). If something went wrong an appropriate task </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotes([FromRoute] int id, [FromBody] Notes notes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notes.NoteId)
            {
                return BadRequest();
            }

            _context.Entry(notes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotesExists(id))
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

        // POST: api/Notes
        /// <summary>
        /// Makes a new note.
        /// </summary>
        /// <param name="notes"> The note to be added to the database </param>
        /// <returns> Hopefully the JSON for the note, unless something goes wrong. </returns>
        [HttpPost]
        public async Task<IActionResult> PostNotes([FromBody] Notes notes)
        {
            notes.NoteId = _context.Notes.Count() + 1;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Notes.Add(notes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NotesExists(notes.NoteId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNotes", new { id = notes.NoteId }, notes);
        }

        /// <summary>
        /// Changes attribute isArchived to 1
        /// </summary>
        /// <param name="id"> The id of the note someone wants to delete </param>
        /// <returns> An appropriate task. Hopefully NoContent(). </returns>
        // DELETE: api/Notes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notes = await _context.Notes.FindAsync(id);
            notes.IsArchived = 1;

            _context.Entry(notes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

            /*if (notes == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(notes);
            await _context.SaveChangesAsync();*/

            //return Ok(notes);
        }

        private bool NotesExists(int id)
        {
            return _context.Notes.Any(e => e.NoteId == id);
        }
    }
}