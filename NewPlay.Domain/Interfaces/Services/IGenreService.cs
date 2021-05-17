using System.Collections.Generic;
using NewPlay.Domain.Models;

namespace NewPlay.Domain.Interfaces.Services
{
    public interface IGenreService
    {
        bool Add(Genre genre);
        bool Update(Genre genre);
        bool Disable(int id, string disableUserId);
        List<Genre> GetGenres();
        Genre GetGenreById(int id);
    }
}