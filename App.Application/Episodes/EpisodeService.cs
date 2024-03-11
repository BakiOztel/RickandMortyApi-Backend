using App.Application.Common.Interfaces;
using App.Data.Context;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Episodes
{
    public class EpisodeService : IEpisode
    {
        private readonly AppDataContext _context;
        public EpisodeService(AppDataContext context)
        {
            _context = context;
        }
        public async Task<Episode> GetEpisode(int id)
        {
            var data = await _context.Episode.Where(e => e.Id == id).Include(e => e.Characters).FirstOrDefaultAsync();
            return data;
        }


        public async Task<List<Episode>> GetEpisodes(string name , string episode)
        {

            var data = await _context.Episode.Include(e => e.Characters).Where(e => (string.IsNullOrEmpty(name) || e.name.StartsWith(name)) && 
            (string.IsNullOrEmpty(episode) || e.episode == episode)).ToListAsync();
            return data;
        }
    }
}
