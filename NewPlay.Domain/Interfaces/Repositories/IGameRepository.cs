using NewPlay.Domain.Models;
using System.Collections.Generic;
using System;

namespace NewPlay.Domain.Interfaces
{
    public interface IGameRepository: IRepository<Game>
    {
         List<Game> GetGamesByUserId(string userId);

         object FilterBy(string id, DateTime? startDate, 
            DateTime? finishDate, bool? active);
    }
}