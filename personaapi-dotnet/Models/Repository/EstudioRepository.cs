using Microsoft.EntityFrameworkCore;
using personaapi_dotnet.Models.Entities;

namespace personaapi_dotnet.Models.Repository
{
    public class EstudioRepository : IEstudioRepository
    {
        private readonly PersonaDbContext _context;

        public EstudioRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public async Task<Estudio> CreateEstudioAsync(Estudio estudio)
        {
            _context.Estudios.Add(estudio);
            await _context.SaveChangesAsync();
            return estudio;
        }

        public async Task<bool> DeleteEstudioAsync(int idProf, int ccPer)
        {
            var estudio = await _context.Estudios.FirstOrDefaultAsync(e => e.IdProf == idProf && e.CcPer == ccPer);
            if (estudio == null)
                return false;

            _context.Estudios.Remove(estudio);
            await _context.SaveChangesAsync();
            return true;
        }

        public Estudio GetEstudioByIds(int idProf, int ccPer)
        {
            return _context.Estudios.FirstOrDefault(e => e.IdProf == idProf && e.CcPer == ccPer);
        }

        public IEnumerable<Estudio> GetAllEstudios()
        {
            return _context.Estudios.ToList();
        }

        public async Task<bool> UpdateEstudioAsync(Estudio estudio)
        {
            _context.Entry(estudio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudioExists(estudio.IdProf, estudio.CcPer))
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

        private bool EstudioExists(int idProf, int ccPer)
        {
            return _context.Estudios.Any(e => e.IdProf == idProf && e.CcPer == ccPer);
        }
    }
}
