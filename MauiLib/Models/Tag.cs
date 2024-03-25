using MauiLib.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MauiLib.Models
{
    public record Tag : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}