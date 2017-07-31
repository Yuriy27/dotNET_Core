using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BSA_netCore.Models.EF
{
    public static class DbInitializer
    {
        public static void Initialize(PlayersContext context)
        {
            context.Database.Migrate();

            if (context.Players.Any())
            {
                return;
            }
            var players = new []
            {
                new Player {Age = 12, Name = "Name1", Team = "Team1"},
                new Player {Age = 12, Name = "Name2", Team = "Team2"},
                new Player {Age = 12, Name = "Name3", Team = "Team3"},
                new Player {Age = 12, Name = "Name4", Team = "Team4"},
                new Player {Age = 12, Name = "Name5", Team = "Team5"},
            };
            foreach (var p in players)
            {
                context.Players.Add(p);
            }
            context.SaveChanges();
        }
    }
}
