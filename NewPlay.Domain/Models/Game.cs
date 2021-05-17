using System.ComponentModel.DataAnnotations;
using System;

namespace NewPlay.Domain.Models
{
    public class Game : BaseModel
    {
        [Key]
        public string Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        public string Cover { get; set; }

        public int PublisherId { get; set; }

        public int DeveloperId { get; set; }
    }
}