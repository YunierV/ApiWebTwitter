using ApiWebTwitter.Dtos;
using ApiWebTwitter.Models;

namespace ApiWebTwitter.Services
{
    public class FollowService
    {
        private readonly UserService _userService;

        public FollowService(UserService userService)
        {
            _userService = userService;
        }

        public RespuestaDTO SeguirUsuario(string follower, string followed)
        {
            RespuestaDTO res = new RespuestaDTO();

            // Validar usuarios por alias
            User userFollower = _userService.ObtenerUsuarioPorAlias(follower);

            if (userFollower == null)
            {
                res.Exito = false;
                res.Mensaje = "Usuario seguidor no encontrado";

                return res;
            }

            User userFollowed = _userService.ObtenerUsuarioPorAlias(followed);
            if (userFollowed == null)
            {
                res.Exito = false;
                res.Mensaje = "Usuario seguido no encontrado";

                return res;
            }

            // Verificar si ya sigue al usuario
            var findFollow = userFollower.Followeds.Find(user => user.UserFollowed.NickName == userFollowed.NickName);
            if(findFollow != null)
            {
                res.Exito = false;
                res.Mensaje = "Usuario ya seguido";

                return res;
                
            }

            // Agregar seguidor al usuario seguido
            Followed follow = new Followed(userFollower, userFollowed);
            userFollower.Followeds.Add(follow);

            // Generar respuesta de exito
            res.Exito = true;
            res.Mensaje = "Usuario seguido correctamente";

            return res;
        }
    }
}
