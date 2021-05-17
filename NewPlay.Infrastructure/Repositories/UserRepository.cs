using NewPlay.Domain.Models;
using NewPlay.Domain.Interfaces;
using NewPlay.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using System;

namespace NewPlay.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public object FilterBy(string id, DateTime? startDate, 
        DateTime? finishDate, bool? active, string accessType){
            using(var db = new NewPlayDbContext()){
                var users = db.User.ToList();
                Predicate<User> match = null;

                if(!string.IsNullOrEmpty(id))
                    match = (u => u.Id == id);
                
                if(!string.IsNullOrEmpty(accessType))
                    match = (u => u.Role == accessType);

                if(startDate != null && finishDate != null){
                    finishDate = Convert.ToDateTime(finishDate)
                    .AddHours(23).AddMinutes(59).AddSeconds(59);

                    match = (u => u.CreationDate >= startDate 
                    && u.CreationDate <= finishDate);
                }
                
                if(active != null){
                    if(active == true)
                        match = (u => u.DisableDate == null);
                    else
                        match = (u => u.DisableDate != null);
                }

                return users.FindAll(match);
            }
        }

        public object GetAssociatedGamesPlatformAndGenres(string id){
             using(var db = new NewPlayDbContext()){
                var user =(from users in db.User 
                            // join userGame in db.UserGame on users.Id equals userGame.UserId
                            // join games in db.Game on userGame.GameId equals games.Id 
                            join userGenre in db.UserGenre on users.Id equals userGenre.UserId
                            join genres in db.Genre on userGenre.GenreId equals genres.Id 
                            join userPlatform in db.UserPlatform on users.Id equals userPlatform.UserId
                            join platform in db.Platform on userPlatform.PlatformId equals platform.Id 
                            where users.Id == id
                            select users).FirstOrDefault();
                
                var _games = (from userGame in db.UserGame
                            join games in db.Game on userGame.GameId equals games.Id
                            where userGame.UserId == user.Id
                            select games).ToList();
                
                var _genres = (from userGenre in db.UserGenre 
                            join genres in db.Genre on userGenre.GenreId equals genres.Id 
                            where userGenre.UserId == user.Id
                            select genres).ToList();

                 var _platforms = (from userPlatform in db.UserPlatform
                            join platform in db.Platform on userPlatform.PlatformId equals platform.Id 
                            where userPlatform.UserId == user.Id
                            select platform).ToList();
                
                return new {
                    user.Nickname,
                    user.Email,
                    user.Avatar,
                    user.CreationDate,
                    user.Description,
                    _games,
                    _genres,
                    _platforms
                };
            }
        }
    }
}