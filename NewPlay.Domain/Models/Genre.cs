using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewPlay.Domain.Models
{
    public class Genre : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }               
    }
}