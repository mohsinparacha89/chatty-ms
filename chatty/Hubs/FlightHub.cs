using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatty.Hubs
{
    public class FlightHub : Hub<IFlightClient>
    {

    }
}
