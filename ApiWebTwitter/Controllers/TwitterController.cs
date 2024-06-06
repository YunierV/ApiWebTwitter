using ApiWebTwitter.Dtos;
using ApiWebTwitter.Models;
using ApiWebTwitter.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiWebTwitter.Controllers
{
    [ApiController]
    [Route("api/twitter")]
    public class TwitterController : ControllerBase
    {
        private readonly PublicationService _publicationService;
        private readonly FollowService _followService;
        private readonly ReadService _readService;
        private readonly UserService _userService;

        public TwitterController(PublicationService publicationService, FollowService followService, UserService userService, ReadService readService)
        {
            _publicationService = publicationService;
            _followService = followService;
            _userService = userService;
            _readService = readService;
            
        }

        [HttpPost("post")]
        public IActionResult Publicar(PublicacionDTO publicacionDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var respuesta = _publicationService.Publicar(publicacionDTO.Author, publicacionDTO.Content);

            if (respuesta != null)
            {
                return Ok(respuesta);
            }
            else
            {
                return BadRequest(respuesta);
            }
        }

        [HttpPost("follow")]
        public IActionResult SeguirUsuario(SeguirDTO seguirDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var respuesta = _followService.SeguirUsuario(seguirDTO.AliasSeguidor, seguirDTO.AliasSeguido);

            return Ok(respuesta);
            //if (respuesta)
            //{
            //    return Ok(respuesta);
            //}
            //else
            //{
            //    return BadRequest(respuesta);
            //}
        }

        [HttpGet("dashboard/{user}")]
        public IActionResult LeerTimeline(string user)
        {
            if (string.IsNullOrEmpty(user))
            {
                return BadRequest("El alias del usuario es obligatorio.");
            }

            var respuesta = _readService.LeerTimeline(user);

            if (respuesta != null)
            {
                return Ok(respuesta);
            }
            else
            {
                return BadRequest(respuesta);
            }
        }

        [HttpPost("Registrarusuario")]
        public List<User> RegistrarUsuario(UsuarioDto user)
        {
            _userService.RegistrarUsuario(user.Name, user.NcikName);
            //return Ok(new
            //{
            //    message="Usuario registrado"
            //});
            var usuarios = _userService.GetUsuarios();
            return usuarios;
        
        }

    }
}
