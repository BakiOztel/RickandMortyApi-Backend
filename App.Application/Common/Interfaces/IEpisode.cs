using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Common.Interfaces
{
    public interface IEpisode
    {

        Task<Episode> GetEpisode(int id);
        Task<List<Episode>>  GetEpisodes(string name, string episode);

    }
}
