using NewPlay.Domain.Models;
using System;

namespace NewPlay.Domain.Interfaces
{
    public interface IPlatformRepository: IRepository<Platform>
    {
         object FilterBy(int? id, DateTime? startDate, 
            DateTime? finishDate, bool? active);
    }
}