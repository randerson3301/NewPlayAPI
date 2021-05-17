using System;
using System.ComponentModel.DataAnnotations;

namespace NewPlay.Domain.Models
{
    public class GamePlatform
    {
        [Key]
        public long Id { get; set; }
        public string GameId { get; set; }
        public int PlatformId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}