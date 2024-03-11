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
            var response = await _episode.GetEpisodes(name, episode);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ApiKeyAuthFilter]
        public async Task<IActionResult> GetEpisode([FromRoute] int id)
        {
            var response = await _episode.GetEpisode(id);
            return Ok(response);
        }
    }
}
