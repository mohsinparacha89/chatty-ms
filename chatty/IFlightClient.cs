using chatty.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatty
{
    public interface IFlightClient
    {
        Task FlightStatusBroadCast(FlightUpdate message);
    }
}
