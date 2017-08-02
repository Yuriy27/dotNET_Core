using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_netCorenetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BSA_netCore.Models.EF
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
            
        }

        public DbSet<Player> Players { get; set; }

        public DbSet<Match> Matches { get; set; }
    }
}
