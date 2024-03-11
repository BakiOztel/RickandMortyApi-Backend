using App.Application.Common.Interfaces;
using App.Application.Episodes;
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

            try
            {
                var data = await _character.GetCharacters(name, status, species, type, gender);

                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("{id}")]
        [ApiKeyAuthFilter]
        public async Task<IActionResult> GetCharacter([FromRoute] int id)
        {

            try
            {
                var data = await _character.GetCharacter(id);

                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error"); 
            }
        }


    }
}
