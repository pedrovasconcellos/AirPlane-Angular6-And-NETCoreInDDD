using System;
using System.Collections.Generic;
using AirPlaneDDD.Application.Interfaces;
using AirPlaneDDD.Domain.Entities;
using AirPlaneDDD.Domain.Interfaces.AirPlanes;

namespace AirPlaneDDD.Application.Apps
{
    public class AppAirPlaneModel : IAppAirPlaneModel
    {
        IAirPlaneModel _IAirPlaneModel;

        public AppAirPlaneModel(IAirPlaneModel iAirPlaneModel)
        {
            this._IAirPlaneModel = iAirPlaneModel;
        }

        public int Add(AirPlaneModel Entity)
        {
            return this._IAirPlaneModel.Add(Entity);
        }

        public int Delete(AirPlaneModel Entity)
        {
            return this._IAirPlaneModel.Delete(Entity);
        }

        public AirPlaneModel GetEntity(Guid id)
        {
            return this._IAirPlaneModel.GetEntity(id);
        }

        public List<AirPlaneModel> List()
        {
            return this._IAirPlaneModel.List();
        }

        public int Update(AirPlaneModel Entity)
        {
            return this._IAirPlaneModel.Update(Entity);
        }
    }
}
