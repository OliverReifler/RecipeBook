namespace RecipeBook.Domain.Dtos
{
    public class RecipeListDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string[] Images { get; set; } = [];
    }
}