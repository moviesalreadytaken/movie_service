using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movie.Models;

namespace movie.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
            _context.Add(new MovieModel(Guid.Empty, "Some film1", new DateOnly(2000, 10, 10), 13, "some film description", 4.6f, null));
            _context.Add(new MovieModel(Guid.Empty, "Some film2", new DateOnly(2001, 10, 10), 0, "some film description", 4.9f, null));
            _context.Add(new MovieModel(Guid.Empty, "Some film3", new DateOnly(2002, 10, 10), 16, "some film description", 3f, null));
            _context.Add(new MovieModel(Guid.Empty, "Some film4", new DateOnly(2003, 10, 10), 18, "some film description", 4f, null));
            _context.Add(new MovieModel(Guid.Empty, "Some film5", new DateOnly(2004, 10, 10), 21, "some film description", 4.1f, null));
            _context.Add(new MovieModel(Guid.Empty, "Some film6", new DateOnly(2005, 10, 10), 13, "some film description", 2.5f, null));
            _context.Add(new MovieModel(Guid.Empty, "Some film7", new DateOnly(2006, 10, 10), 16, "some film description", 4.1f, null));
            _context.Add(new MovieModel(Guid.Empty, "Some film8", new DateOnly(2007, 10, 10), 0, "some film description", 1f, null));
            _context.SaveChanges();
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieModel>>> GetMovieModels()
        {
            if (_context.MovieModels == null)
            {
                return NotFound();
            }
            return await _context.MovieModels.ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieModel>> GetMovieModel(Guid id)
        {
            if (_context.MovieModels == null)
            {
                return NotFound();
            }
            var movieModel = await _context.MovieModels.FindAsync(id);

            if (movieModel == null)
            {
                return NotFound();
            }
            return movieModel;
        }

        [HttpPut("/{id}/url")]
        public async Task<IActionResult> ChangeMovieUrl(Guid id, [FromBody] string url)
        {
            if (!MovieModelExists(id))
            {
                return NotFound();
            }
            var mov = await _context.MovieModels.FindAsync(id);
            if (mov == null)
            {
                return NotFound();
            }
            mov.Url = url;
            _context.Entry(mov).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("/{id}/description")]
        public async Task<IActionResult> ChangeMovieDescription(Guid id, [FromBody] string description)
        {
            if (!MovieModelExists(id))
            {
                return NotFound();
            }
            var mov = await _context.MovieModels.FindAsync(id);
            if (mov == null)
            {
                return NotFound();
            }
            mov.Description = description;
            _context.Entry(mov).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }
        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieModel>> PostMovieModel(MovieModel movieModel)
        {
            if (_context.MovieModels == null)
            {
                return Problem("Entity set 'MovieContext.MovieModels'  is null.");
            }
            movieModel.ID = Guid.Empty;
            _context.MovieModels.Add(movieModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMovieModel", new { id = movieModel.ID }, movieModel);
        }

        private bool MovieModelExists(Guid id)
        {
            return (_context.MovieModels?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
