using NewPlay.Domain.Models;
using System;

namespace NewPlay.Domain.Interfaces
{
    public interface IPublisherRepository: IRepository<Publisher>
    {
         object FilterBy(int? id, DateTime? startDate, 
            DateTime? finishDate, bool? active);
    }
}