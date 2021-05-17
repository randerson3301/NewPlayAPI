using NewPlay.Domain.Models;
using NewPlay.Infrastructure.Context;
using NewPlay.Domain.Interfaces;
using System.Linq;
using System;

namespace NewPlay.Infrastructure.Repositories
{
    public class PlatformRepository : RepositoryBase<Platform>, IPlatformRepository
    {
        public object FilterBy(int? id, DateTime? startDate, 
            DateTime? finishDate, bool? active){
                using(var db = new NewPlayDbContext()){
                var platforms = db.Platform.ToList();
                Predicate<Platform> match = null;

                if(id != null)
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

                return platforms.FindAll(match);
            }
        }
    }
}