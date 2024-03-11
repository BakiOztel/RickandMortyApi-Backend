using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Common.Interfaces
{
    public interface ICharacter
    {
        Task<Character> GetCharacter(int id);
        Task<List<Character>> GetCharacters(string name, string status, string species,
            string type, string gender);
    }
}
