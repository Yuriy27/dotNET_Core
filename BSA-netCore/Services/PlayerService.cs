using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_netCore.Models;
using BSA_netCore.Models.EF;

namespace BSA_netCore.Services
{
    public class PlayerService : IPlayerService
    {
        private GameContext _context;

        public PlayerService(GameContext context)
        {
            _context = context;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _context.Players;
        }

        public Player GetPlayer(int id)
        {
            return _context.Players.Find(id);
        }
    }
}
