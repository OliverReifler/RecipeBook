using MauiLib.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MauiLib.Models
{
    public record Review : IEntity
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Person> Persons { get; set; } = [];
        public DateTime Created { get; set; } = DateTime.Now;
        public string? ReviewText { get; set; }
    }
}