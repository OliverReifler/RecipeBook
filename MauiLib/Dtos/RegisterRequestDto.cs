using System.ComponentModel.DataAnnotations;

namespace MauiLib.Dtos
{
    public class RegisterRequestDto : LoginRequestDto
    {
        [Required]
        public required string Name { get; set; }
    }
}