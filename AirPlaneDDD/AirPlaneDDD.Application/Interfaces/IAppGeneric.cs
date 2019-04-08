using System;
using System.Collections.Generic;

namespace AirPlaneDDD.Application.Interfaces
{
    public interface IAppGeneric<T> where T : class
    {
        int Add(T Entity);
        int Update(T Entity);
        int Delete(T Entity);
        T GetEntity(Guid id);
        List<T> List();
    }
}
