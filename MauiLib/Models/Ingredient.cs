using MauiLib.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MauiLib.Models
{
    public record Ingredient : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
    }
}