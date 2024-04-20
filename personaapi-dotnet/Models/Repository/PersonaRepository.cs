using Microsoft.EntityFrameworkCore;
using personaapi_dotnet.Models.Entities;

namespace personaapi_dotnet.Models.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly PersonaDbContext _context;

        public PersonaRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public async Task<Persona> CreatePersonaAsync(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
            return persona;
        }

        public async Task<bool> DeletePersonaAsync(int cc)
        {
            var persona = await _context.Personas.FindAsync(cc);
            if (persona == null)
                return false;

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
            return true;
        }

        public Persona GetPersonaByCc(int cc)
        {
            return _context.Personas.FirstOrDefault(p => p.Cc == cc);
        }

        public IEnumerable<Persona> GetAllPersonas()
        {
            return _context.Personas.ToList();
        }

        public async Task<bool> UpdatePersonaAsync(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(persona.Cc))
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

        private bool PersonaExists(int cc)
        {
            return _context.Personas.Any(p => p.Cc == cc);
        }
    }
}
