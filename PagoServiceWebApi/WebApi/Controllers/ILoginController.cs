using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    internal interface ILoginController
    {
        Task<ActionResult> Login(Usuario usuario);
    }
}
