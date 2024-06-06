using ApiWebTwitter.Models;

namespace ApiWebTwitter.Services
{
    public class UserService
    {
        private readonly List<User> _usuarios;

        public UserService()
        {
            _usuarios = new List<User>();
        }

        public void RegistrarUsuario(string nombre, string nickName)
        {
            // Validar datos de usuario (nombre, alias)

            // Verificar si el alias ya existe
            if (_usuarios.Any(u => u.NickName == nickName))
            {
                throw new Exception("El alias ya existe.");
            }

            // Crear y registrar nuevo usuario
            User usuario = new User(nombre, nickName);
            _usuarios.Add(usuario);

        }

        public User ObtenerUsuarioPorAlias(string nickName)
        {
            // Buscar usuario por alias
            User usuario = _usuarios.FirstOrDefault(u => u.NickName == nickName);
            return usuario;
        }

        public List<User> GetUsuarios()
        {
            return _usuarios;
        }
    }
}
