using NewPlay.Domain.Models;
using System;

namespace NewPlay.Domain.Interfaces
{
    public interface IDeveloperRepository : IRepository<Developer>
    {
         object FilterBy(int? id, DateTime? startDate, 
            DateTime? finishDate, bool? active);
    }
}