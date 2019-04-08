using System;

namespace AirPlaneDDD.Domain.Entities
{
    public class AirPlaneModel
    {
        public AirPlaneModel() { }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}