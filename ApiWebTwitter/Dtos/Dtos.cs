namespace ApiWebTwitter.Dtos
{
    public class PublicacionDTO
    {
        public string Author { get; set; }
        public string Content { get; set; }
    }

    public class RespuestaDTO
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
    }

    public class SeguirDTO
    {
        public string AliasSeguidor { get; set; }
        public string AliasSeguido { get; set; }
    }

    public class PublicacionesDTO
    {
        public List<PublicacionDTO> Publicaciones { get; set; }
    }

    public class UsuarioDto
    {
        public string Name { get; set; }
        public string NcikName { get; set;}
    }


}
