using System.Text.Json;

namespace RecipeBookApp.Models
{
    public record LoggedInUser(int iId, string Name, string Token)
    {
        public string ToJson() =>
            JsonSerializer.Serialize(this);

        public static LoggedInUser LoadFromJson(string? json) =>
            !string.IsNullOrWhiteSpace(json)
            ? JsonSerializer.Deserialize<LoggedInUser>(json)
            : default;
    }
}