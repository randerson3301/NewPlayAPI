using System;
using System.ComponentModel.DataAnnotations;

namespace NewPlay.Domain.Models
{
    public class UserGame
    {
        [Key]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string GameId { get; set; }
        public int PlayingStatus { get; set; }
        public byte Visible { get; set; }
        public DateTime CreationDate { get; set; }
    }
}