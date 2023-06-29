namespace AllSpice.Repositories;

  public class RecipesRepository
    {
        private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
      _db = db;
    }
  
  
   internal Recipe CreateRecipe(Recipe recipeData)
  {
    string sql = @"
    INSERT INTO recipes
    (title, instructions, img, category, creatorId)
    VALUES
    (@title, @instructions, @img, @category, @creatorId);

    SELECT
     recipes.*,
     creator.*
    FROM recipes
    JOIN accounts creator ON recipes.creatorId = creator.id
    WHERE recipes.id = LAST_INSERT_ID();
    ";
   
    Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator) =>
    {
      recipe.Creator = creator;
      return recipe; 

    }, recipeData).FirstOrDefault();
    return recipe;
  }
  }
