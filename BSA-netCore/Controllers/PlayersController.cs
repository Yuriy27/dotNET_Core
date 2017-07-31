using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_netCore.Models;
using BSA_netCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BSA_netCore.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        private IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public IEnumerable<Player> GetAll()
        {
            return _playerService.GetPlayers();
        }

        //// GET api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
