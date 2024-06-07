using ApiWebTwitter.Models;

namespace ApiWebTwitter.Services
{
    public class UserService
    {
        private readonly List<User> _users;

        public UserService()
        {
            _users =
            [
                new User("Alfonso", "@Alfonso"),
                new User("Alicia", "@Alicia"),
                new User("Ivan", "@Ivan"),
            ];

        }

        public void RegistrarUsuario(string name, string nickName)
        {
            // Validar datos de usuario
            // Verificar si el alias ya existe
            if (_users.Any(u => u.NickName == nickName))
            {
                throw new Exception("El alias ya existe.");
            }

            // Crear y registrar nuevo usuario
            User user = new User(name, nickName);
            _users.Add(user);

        }

        public User ObtenerUsuarioPorAlias(string nickName)
        {
            // Buscar usuario por alias
            User user = _users.FirstOrDefault(u => u.NickName == nickName);
            return user;
        }

        public List<User> GetUsuarios()
        {
            return _users;
        }
    }
}
