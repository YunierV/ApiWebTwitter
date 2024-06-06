using ApiWebTwitter.Models;

namespace ApiWebTwitter.Services
{
    public class ReadService
    {
        private readonly UserService _userService;

        public ReadService(UserService userService)
        {
            _userService = userService;
        }

        public dynamic LeerTimeline(string nickName)
        {
            // Validar usuario por alias
            User usuario = _userService.ObtenerUsuarioPorAlias(nickName);
            if (usuario == null)
            {
                return new { error = $"Usuario no encontrado {nickName}" };
            }

            // Obtener publicaciones del timeline del usuario y sus seguidos
            List<Publication> publicaciones = new List<Publication>();
            publicaciones.AddRange(usuario.Publications);

            foreach (Followed follows in usuario.Followeds)
            {
                publicaciones.AddRange(follows.UserFollowed.Publications);
            }

            // Ordenar las publicaciones por fecha (más reciente primero)
            publicaciones.Sort((a, b) => b.CreatedDate.CompareTo(a.CreatedDate));

            // Generar respuesta JSON con las publicaciones del timeline
            var respuesta = new
            {
                publicaciones = publicaciones.Select(p => new
                {
                    autor = p.Author.NickName,
                    mensaje = p.Content,
                    fecha = p.CreatedDate.ToString("HH:mm")
                })
            };

            return respuesta;
        }
    }
}
