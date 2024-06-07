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

            var res = _publicationService.Publicar(publicacionDTO.Author, publicacionDTO.Content);

            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }

        [HttpPost("follow")]
        public IActionResult SeguirUsuario(SeguirDTO seguirDTO)
        {

            var res = _followService.SeguirUsuario(seguirDTO.AliasSeguidor, seguirDTO.AliasSeguido);

            if (res.Exito)
            {
                return Ok(res);
            }
            
            return BadRequest(res);
            
        }

        [HttpGet("dashboard")]
        public IActionResult LeerTimeline(string user)
        {
            if (string.IsNullOrEmpty(user))
            {
                return BadRequest("El alias del usuario es obligatorio.");
            }

            var res = _readService.LeerTimeline(user);

            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }

    }
}
