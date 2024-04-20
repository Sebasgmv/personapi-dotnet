using personaapi_dotnet.Models.Entities;

namespace personaapi_dotnet.Models.Repository
{
    public interface IEstudioRepository
    {
        Task<Estudio> CreateEstudioAsync(Estudio estudio);
        Task<bool> DeleteEstudioAsync(int idProf, int ccPer);
        Estudio GetEstudioByIds(int idProf, int ccPer);
        IEnumerable<Estudio> GetAllEstudios();
        Task<bool> UpdateEstudioAsync(Estudio estudio);
    }
}
