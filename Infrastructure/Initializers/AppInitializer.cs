using Core.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Initializers
{
    public static class AppInitializer
    {
        public static void Init(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<GamesDbContext>();

                if(!context.Games.Any())
                {

                    context.Games.Add(new Game
                    {
                        Name = "Apex",
                        Producer = "EA"
                    });
                    context.Games.Add(new Game {
                        Name = "CS-GO",
                        Producer = "Valve"
                    });
                }

                context.SaveChanges();
            }
        }
    }
}
