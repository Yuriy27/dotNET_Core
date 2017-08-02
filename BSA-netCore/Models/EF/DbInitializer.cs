using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_netCorenetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BSA_netCore.Models.EF
{
    public static class DbInitializer
    {
        public static void Initialize(GameContext context)
        {
            context.Database.Migrate();

            var players = new []
            {
                new Player {Age = 22, Name = "Name1", Team = "Team1"},
                new Player {Age = 32, Name = "Name2", Team = "Team2"},
                new Player {Age = 25, Name = "Name3", Team = "Team3"},
                new Player {Age = 30, Name = "Name4", Team = "Team4"},
                new Player {Age = 19, Name = "Name5", Team = "Team5"}
            };
            var matches = new[]
            {
                new Match {Owner = "OwnerTeam1", Guest = "GuestTeam1"},
                new Match {Owner = "OwnerTeam2", Guest = "GuestTeam2"},
                new Match {Owner = "OwnerTeam3", Guest = "GuestTeam3"},
                new Match {Owner = "OwnerTeam4", Guest = "GuestTeam4"},
                new Match {Owner = "OwnerTeam5", Guest = "GuestTeam5"}
            };
            if (!context.Players.Any())
            {
                foreach (var p in players)
                {
                    context.Players.Add(p);
                }
            }
            if (!context.Matches.Any())
            {
                foreach (var m in matches)
                {
                    context.Matches.Add(m);
                }
            }
            
            context.SaveChanges();
        }
    }
}
