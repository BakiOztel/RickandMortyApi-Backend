using App.Application.Characters;
using App.Application.Common.Interfaces;
using App.Application.Episodes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreApplication(this IServiceCollection services)
        {   
            services.AddScoped<IEpisode, EpisodeService>();
            services.AddScoped<ICharacter, CharacterService>();
            return services;
        }
    }
}
