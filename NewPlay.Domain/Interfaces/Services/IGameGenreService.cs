using System.Collections.Generic;
using NewPlay.Domain.Models;

namespace NewPlay.Domain.Interfaces.Services
{
    public interface IGameGenreService
    {
        bool Add(GameGenre gameGenre);
        bool Remove(GameGenre gameGenre);
        List<GameGenre> GetGameGenres();
    }
}