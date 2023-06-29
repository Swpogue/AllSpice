namespace AllSpice.Services;

  public class RecipesService
    {
        private readonly RecipesRepository _repo;

  public RecipesService(RecipesRepository repo)
  {
    _repo = repo;
  }

  internal Recipe CreateRecipe(Recipe recipeData)
  {
    Recipe recipe = _repo.CreateRecipe(recipeData);
    return recipe;
  }

  internal List<Recipe> GetAllRecipes()
  {
    List<Recipe> recipes = _repo.GetAllRecipes();
    return recipes;
  }

  internal Recipe GetRecipeById(int recipeId)
  {
    Recipe recipe = _repo.GetRecipeById(recipeId);
    if (recipe == null) throw new Exception($"No recipe at id:{recipeId}.");
    return recipe;
  }

  internal Recipe UpdateRecipe(Recipe updateData)
  {
    Recipe original = GetRecipeById(updateData.Id);
    original.Title = updateData.Title != null ? updateData.Title : original.Title;
    original.Instructions = updateData.Instructions != null ? updateData.Instructions : original.Instructions;
    original.Img = updateData.Img != null ? updateData.Img : original.Img;
    original.Category = updateData.Category != null ? updateData.Category : original.Category;

    _repo.UpdateRecipe(original);
    return original;
  }
}
