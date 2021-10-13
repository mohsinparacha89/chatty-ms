using chatty.Data;
using chatty.Hubs;
using chatty.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace chatty
{
    public class FlightBackgroundService : BackgroundService
    {

        IHubContext<FlightHub, IFlightClient> _flightHubContext;

        private readonly IServiceScopeFactory _scopeFactory;

        ILogger<FlightBackgroundService> _log;
        public FlightBackgroundService(IHubContext<FlightHub, IFlightClient> flightHubContext, ILogger<FlightBackgroundService> log, IServiceScopeFactory scopeFactory)
        {
            _flightHubContext = flightHubContext;
            _scopeFactory = scopeFactory;
            _log = log;
        }


        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _log.LogInformation("starting background service...");
            List<AirportEvent> airportEvents = new List<AirportEvent>();
            while (!stoppingToken.IsCancellationRequested)
            {
                
                _log.LogInformation("broadcasting new flight statuses...");
                var updates = GetUpdates();
                foreach (var update in updates)
                {
                    await Task.Delay(1000);
                    await _flightHubContext.Clients.All.FlightStatusBroadCast(update);

                    airportEvents.Add(new AirportEvent() {Id= Guid.NewGuid() , Airline = update.FlightNumber, Event = update.Status, Date = DateTime.Now});
                }

                using (var scope = _scopeFactory.CreateScope())
                {
                    var airportContext = scope.ServiceProvider.GetRequiredService<AirportContext>();
                    airportContext.AirportEvents.AddRange(airportEvents);
                    airportContext.SaveChanges();
                    airportEvents.Clear();
                }

                await Task.Delay(5000, stoppingToken);
            }    
        }


        private List<FlightUpdate> GetUpdates()
        {
            List<FlightUpdate> updates = new List<FlightUpdate>()
            {
                new FlightUpdate()
                {
                    FlightNumber = "EK604",
                    Status = "Landed"
                },
                 new FlightUpdate()
                {
                    FlightNumber = "PK778",
                    Status = "Departed"
                },
                new FlightUpdate()
                {
                    FlightNumber = "TG349",
                    Status = "Delayed"
                },


        };
            return updates;
        }
    }
}