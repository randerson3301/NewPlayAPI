using System;
using System.ComponentModel.DataAnnotations;

namespace NewPlay.Domain.Models
{
    public class User : BaseModel
    {
        [Key]
        public string Id { get; set; }

        public string Nickname { get; set; }

        public string Avatar { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public string Role { get; set; }
    }
}