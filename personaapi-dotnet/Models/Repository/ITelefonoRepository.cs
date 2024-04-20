using personaapi_dotnet.Models.Entities;

namespace personaapi_dotnet.Models.Repository
{
    public interface ITelefonoRepository
    {
        Task<Telefono> CreateTelefonoAsync(Telefono telefono);
        Task<bool> DeleteTelefonoAsync(string num);
        Telefono GetTelefonoByNumero(string num);
        IEnumerable<Telefono> GetAllTelefonos();
        Task<bool> UpdateTelefonoAsync(Telefono telefono);
    }
}
