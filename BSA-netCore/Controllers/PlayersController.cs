using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_netCore.Models;
using BSA_netCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BSA_netCore.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly ILogger _logger;

        public PlayersController(IPlayerService playerService, ILogger<PlayersController> logger)
        {
            _playerService = playerService;
            _logger = logger; 
        }

        [HttpGet]
        public IEnumerable<Player> GetAll()
        {
            _logger.LogInformation("Getting all players");
            return _playerService.GetPlayers();
        }

        [HttpGet("{id}")]
        public Player GetPlayer(int id)
        {
            var player = _playerService.GetPlayer(id);
            if (player == null)
            {
                _logger.LogError($"Failed to get player {id}");
            }
            else
            {
                _logger.LogInformation($"Getting player {id}");
            }
            
            return player;
        }
        
    }
}
