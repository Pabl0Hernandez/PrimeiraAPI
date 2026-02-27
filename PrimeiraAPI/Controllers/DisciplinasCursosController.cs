using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimeiraAPI.Data;
using PrimeiraAPI.Models;

namespace PrimeiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinasCursosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DisciplinasCursosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DisciplinasCursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisciplinaCurso>>> GetDisciplinasCursos()
        {
            return await _context.DisciplinasCursos.ToListAsync();
        }

        // GET: api/DisciplinasCursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DisciplinaCurso>> GetDisciplinaCurso(Guid id)
        {
            var disciplinaCurso = await _context.DisciplinasCursos.FindAsync(id);

            if (disciplinaCurso == null)
            {
                return NotFound();
            }

            return disciplinaCurso;
        }

        // PUT: api/DisciplinasCursos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisciplinaCurso(Guid id, DisciplinaCurso disciplinaCurso)
        {
            if (id != disciplinaCurso.DisciplinaCursoId)
            {
                return BadRequest();
            }

            _context.Entry(disciplinaCurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplinaCursoExists(id))
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

        // POST: api/DisciplinasCursos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DisciplinaCurso>> PostDisciplinaCurso(DisciplinaCurso disciplinaCurso)
        {
            _context.DisciplinasCursos.Add(disciplinaCurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDisciplinaCurso", new { id = disciplinaCurso.DisciplinaCursoId }, disciplinaCurso);
        }

        // DELETE: api/DisciplinasCursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisciplinaCurso(Guid id)
        {
            var disciplinaCurso = await _context.DisciplinasCursos.FindAsync(id);
            if (disciplinaCurso == null)
            {
                return NotFound();
            }

            _context.DisciplinasCursos.Remove(disciplinaCurso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DisciplinaCursoExists(Guid id)
        {
            return _context.DisciplinasCursos.Any(e => e.DisciplinaCursoId == id);
        }
    }
}
