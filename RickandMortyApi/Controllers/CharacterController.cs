using App.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RickandMortyApi.Auth;

namespace RickandMortyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        public readonly ICharacter _character;

        public CharacterController(ICharacter character)
        {
            _character = character;
        }

        [HttpGet]
        [ApiKeyAuthFilter]
        public async Task<IActionResult> GetCharacters(string? name, string? status, string? species,
            string? type, string? gender)
        {
            var data = await _character.GetCharacters(name,status,species,type,gender);
            return Ok(data);
        }

        [HttpGet("{id}")]
        [ApiKeyAuthFilter]
        public async Task<IActionResult> GetCharacter([FromRoute] int id)
        {
            var data =  await _character.GetCharacter(id);
            return Ok(data);
        }


    }
}
