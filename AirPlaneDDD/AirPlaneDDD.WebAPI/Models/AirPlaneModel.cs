using System;
using System.Collections.Generic;
using System.Linq;

namespace AirPlaneDDD.WebAPI.Models
{
    public class AirPlaneModel
    {
        public AirPlaneModel(AirPlaneAddModel airPlane)
        {
            this.Id = Guid.NewGuid();
            this.Code = airPlane.Code;
            this.Model = null;//lembrar
            this.CreationDate = DateTime.Now;
        }

        public Guid Id { get; set; }

        public string Code { get; set; }

        public AirPlaneModelModel Model { get; set; }

        public int NumberOfPassengers { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
