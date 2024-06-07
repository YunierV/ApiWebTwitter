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
            User user = _userService.ObtenerUsuarioPorAlias(nickName);
            if (user == null)
            {
                throw new Exception("Usuario invalido");
            }

            // Obtener publicaciones del timeline del usuario y sus seguidos
            List<Publication> publications = new List<Publication>();
            publications.AddRange(user.Publications);

            foreach (Followed follows in user.Followeds)
            {
                publications.AddRange(follows.UserFollowed.Publications);
            }

            // Ordenar las publicaciones por fecha (más reciente primero)
            publications.Sort((a, b) => b.CreatedDate.CompareTo(a.CreatedDate));

            // Generar respuesta JSON con las publicaciones del timeline
            var res = new
            {
                publications = publications.Select(p => new
                {
                    autor = p.Author.NickName,
                    mensaje = p.Content,
                    fecha = p.CreatedDate.ToString("HH:mm")
                })
            };

            return res;
        }
    }
}
