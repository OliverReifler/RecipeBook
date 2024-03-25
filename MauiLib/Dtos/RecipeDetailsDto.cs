namespace MauiLib.Dtos
{
    public class RecipeDetailsDto : RecipeListDto
    {
        public required string Instructions { get; set; }
        public int[] Ingredients { get; set; } = [];
        public int[] Reviews { get; set; } = [];
        public int[] Tags { get; set; } = [];
    }
}