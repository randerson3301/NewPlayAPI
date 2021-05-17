using NewPlay.Domain.Models;
using System;

namespace NewPlay.Domain.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
         object FilterBy(string id, DateTime? startDate, DateTime? finishDate,
          bool? active, string accessType);

         object GetAssociatedGamesPlatformAndGenres(string id);
    }
}