using System.Collections.Generic;
using NewPlay.Domain.Models;

namespace NewPlay.Domain.Interfaces.Services
{
    public interface IPlatformService
    {
        bool Add(Platform platform);
        bool Update(Platform platform);
        bool Disable(int id, string disableUserId);
        List<Platform> GetPlatforms();
        Platform GetPlatformById(int id);
    }
}