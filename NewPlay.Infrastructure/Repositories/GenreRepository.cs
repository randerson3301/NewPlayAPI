using NewPlay.Domain.Models;
using NewPlay.Infrastructure.Context;
using NewPlay.Domain.Interfaces;
using System.Linq;
using System;

namespace NewPlay.Infrastructure.Repositories
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public object FilterBy(int? id, DateTime? startDate, 
            DateTime? finishDate, bool? active){
                using(var db = new NewPlayDbContext()){
                var genres = db.Genre.ToList();
                Predicate<Genre> match = null;

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

                return genres.FindAll(match);
            }
        }
    }
}