using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_netCore.Models.EF;
using BSA_netCorenetCore.Models;

namespace BSA_netCore.Services
{
    public class MatchesService
    {
        private readonly GameContext _context;

        public MatchesService(GameContext context)
        {
            _context = context;
        }

        public IEnumerable<Match> GetMatches()
        {
            return _context.Matches;
        }

        public Match GetMatch(int id)
        {
            return _context.Matches.Find(id);
        }
    }
}
