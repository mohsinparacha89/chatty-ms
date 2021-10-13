using chatty.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatty.Controllers
{
    [ApiController]
    [Route("api")]
    public class AirTrafficController : ControllerBase
    {
        IHubContext<FlightHub, IFlightClient> _flightHubContext;
        ILogger<AirTrafficController> _log;

        public AirTrafficController(IHubContext<FlightHub, IFlightClient> flightHubContext, ILogger<AirTrafficController> log)
        {
            _flightHubContext = flightHubContext;
            _log = log;
        }

        [HttpPost]
        [Route("something")]
        public IActionResult Get([FromBody] FlightUpdate message)
        {
            _log.LogInformation("incominggggggggg.....");

            _flightHubContext.Clients.All.FlightStatusBroadCast(message);
            return Ok();
        }
    }
}
