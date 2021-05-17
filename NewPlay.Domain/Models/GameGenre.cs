using System;
using System.ComponentModel.DataAnnotations;

namespace NewPlay.Domain.Models
{
    public class GameGenre
    {
        [Key]
        public long Id { get; set; }
        public string GameId { get; set; }
        public int GenreId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}