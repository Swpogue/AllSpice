namespace AllSpice.Services;

  public class IngredientsService
    {
        private readonly IngredientsRepository _repo;

    public IngredientsService(IngredientsRepository repo)
    {
      _repo = repo;
    }

  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    Ingredient ingredient = _repo.CreateIngredient(ingredientData);
    return ingredient;
  }

  internal void DeleteIngredient(int ingredientId)
  {
    int rows = _repo.DeleteIngredient(ingredientId);
    if (rows > 1) new Exception("OH NO!");
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
   List<Ingredient> ingredients = _repo.GetIngredientsByRecipeId(recipeId);
return ingredients;
  }
}
