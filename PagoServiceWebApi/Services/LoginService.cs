using DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginRepository _loginRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPasswordSecurity _passwordSecurity;

        public LoginService(ILoginRepository loginRepository
            , IConfiguration configuration
            , IPasswordSecurity passwordSecurity
            , IUsuarioRepository usuarioRepository)
        {
            _loginRepository = loginRepository;
            _configuration = configuration;
            _passwordSecurity = passwordSecurity;
            _usuarioRepository = usuarioRepository;
        }

        public string GenerarToken(Usuario usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.UsuarioNombre),
                new Claim("fullName", string.Join(" ", usuario.Nombre, usuario.Apellido)),
                new Claim("role",usuario.Rol),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<Usuario> Autenticar(Usuario usuario)
        {
            //Primero busco si el usuario existe
            var usuarios = await _usuarioRepository.Get(x => x.UsuarioNombre == usuario.UsuarioNombre);

            if (usuarios == null || usuarios.ToList().Count == 0)
            {
                return null;
            }
                
            var usuarioDb = usuarios.FirstOrDefault();

            bool isSamePassword = _passwordSecurity.CheckPassword(usuarioDb.Sal, usuario.Contraseña, usuarioDb.Contraseña);

            if(!isSamePassword)
            {
                return null;
            }

            usuarioDb.Contraseña = string.Empty;
            usuarioDb.Sal = string.Empty;

            return usuarioDb;
            
        }
    }
}
