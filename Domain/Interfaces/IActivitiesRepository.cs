using System;
using System.Linq;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IActivitiesRepository : IRepositoryBase<Activity, Guid>
    {
    }
}