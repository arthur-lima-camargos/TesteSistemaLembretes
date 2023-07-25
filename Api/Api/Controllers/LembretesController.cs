using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;
using Api.DbContexts;
using Api.Base;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LembretesController : CoreController<Lembrete>
    {
        private readonly LembreteContext _context;

        public LembretesController(LembreteContext context): base(context)
        {
            _context = context;
        }

        // GET: api/Lembretes
        [HttpGet]
        public ActionResult<IEnumerable<Lembrete>> GetLembretes()
        {
          if (_context.Lembretes == null)
          {
              return NotFound();
          }
            return new JsonResult(this.GetAll());
        }

        // GET: api/Lembretes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lembrete>> GetLembrete(Guid? id)
        {
          if (_context.Lembretes == null)
          {
              return NotFound();
          }
            var lembrete = await _context.Lembretes.FindAsync(id);

            if (lembrete == null)
            {
                return NotFound();
            }

            return lembrete;
        }

        // PUT: api/Lembretes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLembrete(Guid? id, Lembrete lembrete)
        {
            if (id != lembrete.Id)
            {
                return BadRequest();
            }

            _context.Entry(lembrete).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LembreteExists(id))
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

        // POST: api/Lembretes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lembrete>> PostLembrete(Lembrete lembrete)
        {
          if (_context.Lembretes == null)
          {
              return Problem("Entity set 'LembreteContext.Lembretes'  is null.");
          }
            _context.Lembretes.Add(lembrete);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLembrete), new { id = lembrete.Id }, lembrete);
        }

        // DELETE: api/Lembretes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLembrete(Guid? id)
        {
            if (_context.Lembretes == null)
            {
                return NotFound();
            }
            var lembrete = await _context.Lembretes.FindAsync(id);
            if (lembrete == null)
            {
                return NotFound();
            }

            _context.Lembretes.Remove(lembrete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LembreteExists(Guid? id)
        {
            return (_context.Lembretes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
