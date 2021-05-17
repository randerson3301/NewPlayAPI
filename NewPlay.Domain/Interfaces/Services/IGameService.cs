using System.Collections.Generic;
using NewPlay.Domain.Models;

namespace NewPlay.Domain.Interfaces.Services
{
    public interface IGameService
    {
        bool Add(Game game);
        bool Update(Game game);
        bool Disable(int id, string disableUserId);
        List<Game> GetGames();
        Game GetGameById(int id);
    }
}