using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NewPlay.Domain.Models
{
    public class Platform : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Type { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}