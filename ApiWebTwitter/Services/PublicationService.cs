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

        public dynamic Publicar(string nickName, string content)
        {
            // Validar usuario por alias
            User user = _userService.ObtenerUsuarioPorAlias(nickName);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            // Crear y publicar la publicación
            Publication publication = new Publication(user, content);
            user.Publications.Add(publication);

            // Generar respuesta JSON con la información de la publicación
            var res = new
            {
                autor = user.NickName,
                mensaje = publication.Content,
                fecha = publication.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss")
            };

            return res;
        }
    }
}
