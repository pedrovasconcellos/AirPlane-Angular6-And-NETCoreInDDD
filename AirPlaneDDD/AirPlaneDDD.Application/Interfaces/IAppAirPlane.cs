
using AirPlaneDDD.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AirPlaneDDD.Application.Interfaces
{
    public interface IAppAirPlane : IAppGeneric<AirPlane>
    {
        int? Delete(Guid id);
        Result<AirPlane> AddEntity(AirPlane Entity);
        List<AirPlane> List(string code, string model, short? numberOfPassengers, DateTime? creationDate);
        Result<AirPlane> Update(Guid identifier, AirPlane Entity);
    }
}
