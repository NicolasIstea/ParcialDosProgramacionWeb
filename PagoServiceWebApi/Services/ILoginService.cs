using Models;
using System.Threading.Tasks;

namespace Services
{
    public interface ILoginService
    {
        string GenerarToken(Usuario usuario);
        Task<Usuario> Autenticar(Usuario usuario);
    }
}
