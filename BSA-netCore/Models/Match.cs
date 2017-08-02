using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace BSA_netCorenetCore.Models
{
    public class Match
    {
        public int Id { get; set; }

        public string Owner { get; set; }

        public string Guest { get; set; }
    }
}
