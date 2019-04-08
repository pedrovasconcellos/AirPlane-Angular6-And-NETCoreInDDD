using AirPlaneDDD.Domain.Entities;
using AirPlaneDDD.Domain.Interfaces.AirPlanes;
using AirPlaneDDD.Infra.Repository.Generic;

namespace AirPlaneDDD.Infra.Repository.AirPlanes
{
    public class RepositoryAirPlane : RepositoryGeneric<AirPlane>, IAirPlane
    {

    }
}
