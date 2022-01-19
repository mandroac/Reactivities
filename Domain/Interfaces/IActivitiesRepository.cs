using System;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IActivitiesRepository : IRepositoryBase<Activity, Guid>
    {
    }
}