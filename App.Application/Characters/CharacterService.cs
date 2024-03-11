using App.Application.Common.Interfaces;
using App.Data.Context;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Characters
{
    public class CharacterService : ICharacter
    {
        private readonly AppDataContext _context;
        public CharacterService(AppDataContext context)
        {
            _context = context;
        }
        public async Task<Character> GetCharacter(int id)
        {
            var data = await _context.Character.Where(e => e.Id == id).Include(e => e.Episodes).FirstOrDefaultAsync();
            return data;
        }

        public async Task<List<Character>> GetCharacters(string name, string status, string species,
            string type, string gender)
        {
            
            var data = await _context.Character.Include(e => e.Episodes)
            .Where(e => (string.IsNullOrEmpty(name) || e.name.StartsWith(name)) && 
                         (string.IsNullOrEmpty(status) || e.status == status) &&
                         ((string.IsNullOrEmpty(species) || e.species== species)) &&
                         (string.IsNullOrEmpty(type)|| e.type == type) && 
                         (string.IsNullOrEmpty(gender) ||  e.gender == gender))
                .ToListAsync();
            return data;
        }
    }
}
