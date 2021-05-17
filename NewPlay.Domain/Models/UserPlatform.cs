using System;
using System.ComponentModel.DataAnnotations;

namespace NewPlay.Domain.Models
{
    public class UserPlatform
    {
        [Key]
        public string Id { get; set; }
        public string UserId { get; set; }
        public int PlatformId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}