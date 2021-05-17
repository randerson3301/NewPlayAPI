using NewPlay.Domain.Models;
using NewPlay.Domain.Interfaces;
using System.Collections.Generic;
using NewPlay.Infrastructure.Context;
using System.Linq;
using System;

namespace NewPlay.Infrastructure.Repositories
{
    public class GameRepository: RepositoryBase<Game>, IGameRepository
    {
        public List<Game> GetGamesByUserId(string userId){
            using(var db = new NewPlayDbContext()){
                var games = (from _games in db.Game 
                            join gameGenre in db.GameGenre on _games.Id equals gameGenre.GameId 
                            join gamePlatf in db.GamePlatform on _games.Id equals gamePlatf.GameId
                            join userGenre in db.UserGenre on gameGenre.GenreId equals userGenre.GenreId  
                            join userPlatf in db.UserPlatform on gamePlatf.PlatformId equals userPlatf.PlatformId
                            where userPlatf.UserId == userId && userGenre.UserId == userId
                            && db.UserGame.Where(ug => ug.GameId ==_games.Id).First() == null
                            select _games).ToList(); 
                
                return games;
            }
        }

        public object FilterBy(string id, DateTime? startDate, 
            DateTime? finishDate, bool? active){
                using(var db = new NewPlayDbContext()){
                var games = db.Game.ToList();
                Predicate<Game> match = null;

                if(!string.IsNullOrEmpty(id))
                    match = (e => e.Id == id);

                if(startDate != null && finishDate != null){
                    finishDate = Convert.ToDateTime(finishDate)
                    .AddHours(23).AddMinutes(59).AddSeconds(59);

                    match = (e => e.CreationDate >= startDate 
                    && e.CreationDate <= finishDate);
                }
                
                if(active != null){
                    if(active == true)
                        match = (e => e.DisableDate == null);
                    else
                        match = (e => e.DisableDate != null);
                }

                return games.FindAll(match);
            }
        }

    }
}