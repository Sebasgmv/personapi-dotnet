using Microsoft.EntityFrameworkCore;
using personaapi_dotnet.Models.Entities;

namespace personaapi_dotnet.Models.Repository
{
    public class ProfesionRepository : IProfesion
    {
        private readonly PersonaDbContext _context;

        public ProfesionRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public async Task<Profesion> CreateProfesionAsync(Profesion profesion)
        {
            _context.Profesions.Add(profesion);
            await _context.SaveChangesAsync();
            return profesion;
        }

        public async Task<bool> DeleteProfesionAsync(int id)
        {
            var profesion = await _context.Profesions.FindAsync(id);
            if (profesion == null)
                return false;

            _context.Profesions.Remove(profesion);
            await _context.SaveChangesAsync();
            return true;
        }

        public Profesion GetProfesionById(int id)
        {
            return _context.Profesions.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Profesion> GetAllProfesiones()
        {
            return _context.Profesions.ToList();
        }

        public async Task<bool> UpdateProfesionAsync(Profesion profesion)
        {
            _context.Entry(profesion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesionExists(profesion.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        private bool ProfesionExists(int id)
        {
            return _context.Profesions.Any(p => p.Id == id);
        }
    }
}
