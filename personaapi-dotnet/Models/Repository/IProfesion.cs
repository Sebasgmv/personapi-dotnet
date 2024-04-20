using personaapi_dotnet.Models.Entities;

namespace personaapi_dotnet.Models.Repository
{
    public interface IProfesion
    {
        Task<Profesion> CreateProfesionAsync(Profesion profesion);
        Task<bool> DeleteProfesionAsync(int id);
        Profesion GetProfesionById(int id);
        IEnumerable<Profesion> GetAllProfesiones();
        Task<bool> UpdateProfesionAsync(Profesion profesion);
    }
}
