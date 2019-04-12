using AirPlane.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirPlane.WebAPI.Repository
{
    internal static class AirPlaneRepository
    {
        internal static IList<AirPlaneModel> AirPlanes { get; set; }

        internal static IList<AirPlaneModelModel> AirPlanModels { get; set; }

        internal static void SetDefault()
        {
            SetDefaultAirPlaneModels();

            var AirbusA300B1 = new AirPlaneModel()
            {
                Id = Guid.Parse("b413cfc0-f53a-4765-9430-3912efcd79cb"),
                Code = "1",
                Model = AirPlanModels.First(x => x.Name == "Airbus A300B1"),
                NumberOfPassengers = 111,
                CreationDate = DateTime.Now
            };

            var AirbusA319 = new AirPlaneModel()
            {
                Id = Guid.Parse("b413cfc0-f53a-4765-9430-3912efcd79cb"),
                Code = "2",
                Model = AirPlanModels.First(x => x.Name == "Airbus A319"),
                NumberOfPassengers = 122,
                CreationDate = DateTime.Now
            };

            var Boeing737_100 = new AirPlaneModel()
            {
                Id = Guid.Parse("a714554f-f363-42f1-b41a-81ee85186660"),
                Code = "3",
                Model = AirPlanModels.First(x => x.Name == "Boeing 737-100"),
                NumberOfPassengers = 167,
                CreationDate = DateTime.Now
            };

            var Boeing737_100_2 = new AirPlaneModel()
            {
                Id = Guid.Parse("a714554f-f363-42f1-b41a-81ee85186622"),
                Code = "3B",
                Model = AirPlanModels.First(x => x.Name == "Boeing 737-100"),
                NumberOfPassengers = 167,
                CreationDate = DateTime.Now
            };

            var BoeingCRJ_100 = new AirPlaneModel()
            {
                Id = Guid.Parse("a714554f-f363-42f1-b41a-81ee85186661"),
                Code = "4",
                Model = AirPlanModels.First(x => x.Name == "Boeing CRJ-100"),
                NumberOfPassengers = 117,
                CreationDate = DateTime.Now
            };

            AirPlanes = new List<AirPlaneModel>
            {
                AirbusA300B1,
                AirbusA319,
                Boeing737_100,
                Boeing737_100_2,
                BoeingCRJ_100
            };
        }

        internal static void SetDefaultAirPlaneModels()
        {
            var AirbusA300B1 = new AirPlaneModelModel()
            {
                Id = Guid.Parse("7f430a38-a6b2-4a8f-96d5-801725dfdfc1"),
                Name = "Airbus A300B1"
            };
            var AirbusA319 = new AirPlaneModelModel()
            {
                Id = Guid.Parse("7f430a38-a6b2-4a8f-96d5-801725dfdfc2"),
                Name = "Airbus A319"
            };
            var Boeing737_100 = new AirPlaneModelModel()
            {
                Id = Guid.Parse("7f430a38-a6b2-4a8f-96d5-801725dfdfc3"),
                Name = "Boeing 737-100"
            };
            var BoeingCRJ_100 = new AirPlaneModelModel()
            {
                Id = Guid.Parse("7f430a38-a6b2-4a8f-96d5-801725dfdfc4"),
                Name = "Boeing CRJ-100"
            };

            AirPlanModels = new List<AirPlaneModelModel>
            {
                AirbusA300B1,
                AirbusA319,
                Boeing737_100,
                BoeingCRJ_100
            };
        }
    }
}
