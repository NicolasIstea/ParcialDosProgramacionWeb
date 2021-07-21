using DataAccess.Repositories;
using Models;
using Models.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class UsuarioService : GenericService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPasswordSecurity _passwordSecurity;
        public UsuarioService(IUsuarioRepository usuarioRepository
            , IPasswordSecurity passwordSecurity) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _passwordSecurity = passwordSecurity;
        }

        public override async Task<Usuario> AddEntity(Usuario entity)
        {
            //Verificar que no exista el usuario previamente
            List<Usuario> usuarios = await _usuarioRepository.Get(x => x.UsuarioNombre == entity.UsuarioNombre);

            if(usuarios.Count > 0)
            {
                throw new ValidationException("2601");
            }

            string sal = _passwordSecurity.GenerateSalt();
            string contraseñaHasheada = _passwordSecurity.HashPassword(entity.Contraseña, sal);

            entity.Sal = sal;
            entity.Contraseña = contraseñaHasheada;
            entity.Rol = "Admin";

            var entidad = await _usuarioRepository.Add(entity);

            entidad.Sal = "";
            entidad.Contraseña = "";

            return entidad;
        }
    }
}
