namespace AllSpice.Repositories;

  public class IngredientsRepository
    {
        private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
      _db = db;
    }

  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
   string sql= @"
   INSERT INTO ingredients
   (name, quantity, recipeId)
   VALUES
   (@name, @quantity, @recipeId);

   SELECT
   ingredients.*,
   recipes.*
   FROM ingredients
   JOIN recipes ON ingredients.recipeId = recipes.Id
   WHERE ingredients.id = LAST_INSERT_ID();
   ";

   Ingredient ingredient = _db.Query<Ingredient, Recipe, Ingredient>(sql,(ingredient, recipe) =>
   {
    ingredient.RecipeId = recipe.Id;
    return ingredient;
   }, ingredientData).FirstOrDefault();
   return ingredient;
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    string sql = @"
    SELECT
    *
    FROM ingredients
    WHERE recipeID = @recipeId;
    ";

    List<Ingredient> recIng = _db.Query<Ingredient>(sql, new {recipeId}).ToList();
    return new List<Ingredient>(recIng);
  
  }
}
