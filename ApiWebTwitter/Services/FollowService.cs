﻿using ApiWebTwitter.Models;

namespace ApiWebTwitter.Services
{
    public class FollowService
    {
        private readonly UserService _userService;

        public FollowService(UserService userService)
        {
            _userService = userService;
        }

        public dynamic SeguirUsuario(string aliasSeguidor, string aliasSeguido)
        {
            // Validar usuarios por alias
            User usuarioSeguidor = _userService.ObtenerUsuarioPorAlias(aliasSeguidor);
            if (usuarioSeguidor == null)
            {
                return new { error = "Usuario seguidor no encontrado." };
            }

            User usuarioSeguido = _userService.ObtenerUsuarioPorAlias(aliasSeguido);
            if (usuarioSeguido == null)
            {
                return new { error = "Usuario seguido no encontrado." };
            }

            // Verificar si ya sigue al usuario
            var findFollow = usuarioSeguidor.Followeds.Find(user => user.UserFollowed.NickName == usuarioSeguido.NickName);
            if(findFollow != null)
            {
                return new { error = "Usuario ya seguido" };
            }

            // Agregar seguidor al usuario seguido
            Followed follow = new Followed(usuarioSeguidor, usuarioSeguido);
            usuarioSeguidor.Followeds.Add(follow);
            

            // Generar respuesta JSON indicando éxito
            return new { mensaje = "Usuario seguido correctamente."};
        }
    }
}
