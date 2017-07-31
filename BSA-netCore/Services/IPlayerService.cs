using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_netCore.Models;

namespace BSA_netCore.Services
{
    public interface IPlayerService
    {
        IEnumerable<Player> GetPlayers();
    }
}
