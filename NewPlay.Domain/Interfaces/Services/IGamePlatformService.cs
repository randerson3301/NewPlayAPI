using System.Collections.Generic;
using NewPlay.Domain.Models;

namespace NewPlay.Domain.Interfaces.Services
{
    public interface IGamePlatformService
    {
        bool Add(GamePlatform gameGenre);
        bool Remove(GamePlatform gameGenre);
        List<GamePlatform> GetGamePlatforms();
    }
}