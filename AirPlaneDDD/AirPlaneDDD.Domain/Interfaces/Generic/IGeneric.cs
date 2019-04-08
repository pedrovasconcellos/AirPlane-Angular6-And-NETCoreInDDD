using System;
using System.Collections.Generic;

namespace AirPlaneDDD.Domain.Interfaces.Generic
{
    public interface IGeneric<T> where T : class
    {
        int Add(T Entity);
        int Update(T Entity);
        int Delete(T Entity);
        T GetEntity(Guid id);
        List<T> List();
    }
}
