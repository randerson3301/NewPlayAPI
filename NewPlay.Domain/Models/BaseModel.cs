using System;

namespace NewPlay.Domain.Models
{
    public class BaseModel
    {
        public DateTime? DisableDate { get; set; }
        public string DisableUserId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}