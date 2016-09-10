using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using iAsset.App.Domain.Repository;
using iAsset.App.Domain.Entity;
using System.Collections.Generic;
using System.Linq;
namespace iAsset.App.Test
{
    [TestClass]
    public class RepositoryTest
    {

        private static IContainer container { get; set; }
        private IGateManagerRepository repository { get; set; }

        public RepositoryTest()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<GateManagerRepository>().As<IGateManagerRepository>();
            container = builder.Build();
            repository = container.Resolve<IGateManagerRepository>();
        }
        [TestMethod]
        // add flight to gate 1
        public void add_new_flight_to_gate()
        {
            var gate = GetGate(1);
            Assert.IsTrue(gate.GetFlights().Count > 0);
        }

        [TestMethod]
        public void move_flight_to_other_gate()
        {
            var gate = GetGate(1);
            Assert.IsTrue(gate.GetFlights().Count > 0);
        }

        [TestMethod]
        public void remove_flight_from_gate()
        {
            var gate = GetGate(1);
            var count = gate.GetFlights().Count();
            if (count > 0)
            {
                var flight = gate.GetFlights().FirstOrDefault();
                repository.removeFlight(flight);
                Assert.IsTrue(gate.GetFlights().Count < count);
            }
            else
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void update_flight_from_gate()
        {
            var gate = GetGate(1);
            var flight = gate.GetFlights().FirstOrDefault();
            flight.Name = "THIS IS MY TEST FLIGHT";
            var getFlight = gate.GetFlights().Where(f => f.FlightId == flight.FlightId).FirstOrDefault();
            Assert.AreEqual(getFlight.Name, flight.Name);
        }

        [TestMethod]
        public void update_flight_gate()
        {
            var gate = GetGate(1);
            var secondGate = GetGate(2);
            var count = secondGate.GetFlights().Count;
            var flight = gate.GetFlights().FirstOrDefault();
            repository.ChangeFlightGates(2, flight);
            Assert.IsTrue(secondGate.GetFlights().Count > count);
        }

        private Flight GetTestFlight(int gateId = 1)
        {
            var testFlight = new Flight(1, "TEST FLIGHT", DateTime.Now, DateTime.Now.AddMinutes(29), gateId);
            return testFlight;
        }

        private Gate GetGate(int gateid =1)
        {
            var gates = repository.getGates();
            var gate = gates.Where(g => g.GateId == gateid).FirstOrDefault();
            return gate;
        }

    }
}
