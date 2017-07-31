﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BSA_netCore.Models.EF
{
    public class PlayersContext : DbContext
    {
        public PlayersContext(DbContextOptions<PlayersContext> options) : base(options)
        {
            
        }

        public DbSet<Player> Players { get; set; }
    }
}
