using System;
using System.ComponentModel.DataAnnotations;

namespace NewPlay.Domain.Models
{
    public class UserGenre
    {
        [Key]
        public string Id { get; set; }
        public string UserId { get; set; }
        public int GenreId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}