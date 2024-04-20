using Microsoft.EntityFrameworkCore;
using personaapi_dotnet.Models.Entities;

namespace personaapi_dotnet.Models.Repository
{
    public class TelefonoRepository : ITelefonoRepository
    {
        private readonly PersonaDbContext _context;

        public TelefonoRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public async Task<Telefono> CreateTelefonoAsync(Telefono telefono)
        {
            _context.Telefonos.Add(telefono);
            await _context.SaveChangesAsync();
            return telefono;
        }

        public async Task<bool> DeleteTelefonoAsync(string num)
        {
            var telefono = await _context.Telefonos.FindAsync(num);
            if (telefono == null)
                return false;

            _context.Telefonos.Remove(telefono);
            await _context.SaveChangesAsync();
            return true;
        }

        public Telefono GetTelefonoByNumero(string num)
        {
            return _context.Telefonos.FirstOrDefault(t => t.Num == num);
        }

        public IEnumerable<Telefono> GetAllTelefonos()
        {
            return _context.Telefonos.ToList();
        }

        public async Task<bool> UpdateTelefonoAsync(Telefono telefono)
        {
            _context.Entry(telefono).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefonoExists(telefono.Num))
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

        private bool TelefonoExists(string num)
        {
            return _context.Telefonos.Any(t => t.Num == num);
        }
    }
}
