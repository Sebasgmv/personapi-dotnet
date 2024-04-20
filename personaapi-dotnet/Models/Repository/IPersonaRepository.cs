using personaapi_dotnet.Models.Entities;

namespace personaapi_dotnet.Models.Repository
{
    public interface IPersonaRepository
    {
        Task<Persona> CreatePersonaAsync(Persona persona);
        Task<bool> DeletePersonaAsync(int cc);
        Persona GetPersonaByCc(int cc);
        IEnumerable<Persona> GetAllPersonas();
        Task<bool> UpdatePersonaAsync(Persona persona);
    }
}
