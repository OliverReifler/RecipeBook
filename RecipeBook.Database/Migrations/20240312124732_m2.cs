using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBook.Database.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipesId",
                table: "RecipeIngredients");

            migrationBuilder.RenameColumn(
                name: "RecipesId",
                table: "RecipeIngredients",
                newName: "RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeIngredients_RecipesId",
                table: "RecipeIngredients",
                newName: "IX_RecipeIngredients_RecipeId");

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Name", "Preperation" },
                values: new object[] { 6, "recipe2", null });

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients");

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "RecipeIngredients",
                newName: "RecipesId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients",
                newName: "IX_RecipeIngredients_RecipesId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipesId",
                table: "RecipeIngredients",
                column: "RecipesId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
