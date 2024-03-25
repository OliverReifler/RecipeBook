using MauiLib.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MauiLib.Models
{
    public record Person : IEntity
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}