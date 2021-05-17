using System.ComponentModel.DataAnnotations;
using System;

namespace NewPlay.Domain.Models
{
    public class Publisher : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }       
    }
}