using App.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RickandMortyApi.Auth;

namespace RickandMortyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        public readonly IEpisode _episode;

        public EpisodeController(IEpisode episode)
        {
            _episode = episode;
        }

        [HttpGet]
        [ApiKeyAuthFilter]
        public async Task<IActionResult> GetEpisodes([FromQuery] string? name, [FromQuery] string? episode)
        {
            
            try
            {
                var response = await _episode.GetEpisodes(name, episode);

                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        [ApiKeyAuthFilter]
        public async Task<IActionResult> GetEpisode([FromRoute] int id)
        {

            try
            {
                var response = await _episode.GetEpisode(id);

                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);

            }
            catch(Exception ex) {
                return StatusCode(500, "Internal server error");
            }



        }
    }
}
