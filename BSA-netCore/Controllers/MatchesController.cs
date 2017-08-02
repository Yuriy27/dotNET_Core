using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_netCore.Models;
using BSA_netCore.Services;
using BSA_netCorenetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BSA_netCore.Controllers
{
    [Route("api/[controller]")]
    public class MatchesController : Controller
    {
        private readonly MatchesService _matchesService;

        private readonly ILogger _logger;

        public MatchesController(MatchesService matchesService, ILogger<MatchesController> logger)
        {
            _matchesService = matchesService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Match> GetAll()
        {
            _logger.LogInformation("Getting all matches");
            return _matchesService.GetMatches();
        }

        [HttpGet("{id}")]
        public Match GetPlayer(int id)
        {
            var match = _matchesService.GetMatch(id);
            if (match == null)
            {
                _logger.LogError($"Failed to get match {id}");
            }
            else
            {
                _logger.LogInformation($"Getting match {id}");
            }
            
            return match;
        }
    }
}
