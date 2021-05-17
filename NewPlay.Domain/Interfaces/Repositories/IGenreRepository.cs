using NewPlay.Domain.Models;
using System;

namespace NewPlay.Domain.Interfaces
{
    public interface IGenreRepository: IRepository<Genre>
    {
         object FilterBy(int? id, DateTime? startDate, 
            DateTime? finishDate, bool? active);
    }
}