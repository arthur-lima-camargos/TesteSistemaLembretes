﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;
using Api.DbContexts;
using Api.Base;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LembretesController : CoreController<Lembrete>
    {
        private readonly LembreteContext _context;

        public LembretesController(LembreteContext context) : base(context)
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

            return new JsonResult(this.GetAll().GroupBy(x => DateTime.ParseExact(x.Date, "dd/MM/yyyy", null))
                                  .OrderBy(g => g.Key).ToDictionary(g => g.Key.ToString("dd/MM/yyyy"), g => g.ToList()));
        }

        // GET: api/Lembretes/5
        [HttpGet("{id}")]
        public ActionResult<Lembrete> GetLembrete(string? id)
        {
            if (_context.Lembretes == null)
            {
                return NotFound();
            }
            var lembrete = this.Get(id);

            if (lembrete == null)
            {
                return NotFound();
            }

            return new JsonResult(this.Get(id));
        }

        // PUT: api/Lembretes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutLembrete(string? id, Lembrete lembrete)
        {
            if(id != lembrete.Id)
                return NotFound("Id not founded");

            Regex validateDateRegex = new Regex("^(((0[1-9]|[12]\\d|3[01])\\/(0[13578]|1[02])\\/((19|[2-9]\\d)\\d{2}))|((0[1-9]|[12]\\d|30)\\/(0[13456789]|1[012])\\/((19|[2-9]\\d)\\d{2}))|((0[1-9]|1\\d|2[0-8])\\/02\\/((19|[2-9]\\d)\\d{2}))|(29\\/02\\/((1[6-9]|[2-9]\\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$");
            bool success = validateDateRegex.IsMatch(lembrete.Date);

            if (success == false)
            {
                return BadRequest(error: "The date has to be a valid date like the example: \"dd/MM/yyyy\"");
            }

            try
            {
                this.Update(lembrete);
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
        public IActionResult PostLembrete(Lembrete lembrete)
        {
            if (_context.Lembretes == null)
            {
                return Problem("Entity set 'LembreteContext.Lembretes'  is null.");
            }

            lembrete.Id = Guid.NewGuid().ToString();
            this.Insert(lembrete);

            return Ok();
        }

        // DELETE: api/Lembretes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLembrete(string? id)
        {
            if (_context.Lembretes == null)
            {
                return NotFound();
            }
            var lembrete = this.Get(id);
            if (lembrete == null)
            {
                return NotFound();
            }

            this.Delete(id);

            return Ok();
        }

        [HttpGet("lembreteExists/{id}")]
        public bool LembreteExists(string? id)
        {
            return (_context.Lembretes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
