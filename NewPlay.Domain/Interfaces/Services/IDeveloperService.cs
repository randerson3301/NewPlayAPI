using System.Collections.Generic;
using NewPlay.Domain.Models;

namespace NewPlay.Domain.Interfaces.Services
{
    public interface IDeveloperService
    {
         bool Add(Developer dev);
         bool Update(Developer dev);
         bool Disable(int id, string disableUserId);
         List<Developer> GetDevelopers();
         Developer GetDeveloperById(int id);
    }
}