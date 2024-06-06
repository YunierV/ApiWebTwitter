using ApiWebTwitter.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiWebTwitter.Services
{
    public class PublicationService
    {
        private readonly UserService _userService;

        public PublicationService(UserService userService)
        {
            _userService = userService;
        }

        public dynamic Publicar(string alias, string mensaje)
        {
            // Validar usuario por alias
            User usuario = _userService.ObtenerUsuarioPorAlias(alias);
            if (usuario == null)
            {
                return new { error = "Usuario no encontrado." };
            }

            // Crear y publicar la publicación
            Publication publicacion = new Publication(usuario, mensaje);
            usuario.Publications.Add(publicacion);

            // Generar respuesta JSON con la información de la publicación
            var respuesta = new
            {
                autor = usuario.NickName,
                mensaje = publicacion.Content,
                fecha = publicacion.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss")
            };

            return respuesta;
        }
    }
}
