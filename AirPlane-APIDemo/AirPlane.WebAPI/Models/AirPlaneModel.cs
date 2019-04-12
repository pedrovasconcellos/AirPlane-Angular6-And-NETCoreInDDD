using AirPlane.WebAPI.Repository;
using System;
using System.Linq;

namespace AirPlane.WebAPI.Models
{
    public class AirPlaneModel
    {
        public AirPlaneModel() { }

        public AirPlaneModel(AirPlaneAddModel airPlane)
        {
            this.Id = Guid.NewGuid();
            this.Code = airPlane.Code;
            this.Model = AirPlaneRepository.AirPlanModels.First(x => x.Id == airPlane.Model.Id);
            this.CreationDate = DateTime.Now;
        }

        public Guid Id { get; set; }

        public string Code { get; set; }

        public AirPlaneModelModel Model { get; set; }

        public int NumberOfPassengers { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
