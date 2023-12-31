namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
  private readonly RecipesService _recipesService;
  private readonly Auth0Provider _auth;
  private readonly IngredientsService _ingredientsService;
  private readonly FavoritesService _favoritesService;

  public RecipesController(RecipesService recipesService, Auth0Provider auth, IngredientsService ingredientsService, FavoritesService favoritesService)
  {
    _recipesService = recipesService;
    _auth = auth;
    _ingredientsService = ingredientsService;
    _favoritesService = favoritesService;
  }


  [HttpPost]
  [Authorize]

  public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      recipeData.CreatorId = userInfo.Id;

      Recipe recipe = _recipesService.CreateRecipe(recipeData);
      return new ActionResult<Recipe>(Ok(recipe));
    }
    catch (Exception e)
    {
      return new ActionResult<Recipe>(BadRequest(e.Message));
    }
  }

   [HttpGet]
    public ActionResult<List<Recipe>> GetAllRecipes()
    {
        try
        {
            List<Recipe> recipes = _recipesService.GetAllRecipes();
            return Ok(recipes);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

        [HttpGet("{recipeId}")]
    public ActionResult<Recipe> GetRecipeById(int recipeId)
    {
        try
        {
            Recipe recipe = _recipesService.GetRecipeById(recipeId);
            return Ok(recipe);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

  [HttpPut("{recipeId}")]
   [Authorize]
  public async Task<ActionResult<Recipe>> UpdateRecipe(int recipeId, [FromBody] Recipe updateData)
  {
    try
    {
      updateData.Id = recipeId;
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      updateData.CreatorId = userInfo.Id;
      Recipe recipe = _recipesService.UpdateRecipe(updateData);
      return Ok(recipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

    [HttpDelete("{recipeId}")]
    [Authorize]

    public async Task<ActionResult<string>> DeleteRecipe(int recipeId)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        _recipesService.DeleteRecipe(recipeId, userInfo.Id);
        return Ok("Recipe Deleted");
      }
      catch (Exception e)
      {
        
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{recipeId}/ingredients")]
    public ActionResult<List<Ingredient>> GetIngredientsByRecipeId(int recipeId)
    {
        try
        {
            List<Ingredient> ingredients = _ingredientsService.GetIngredientsByRecipeId(recipeId);
            return Ok(ingredients);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
   
   [HttpGet("{recipeId}/favorites")]

   public ActionResult<List<FavoriteAccount>> GetFavoritesByRecipeId(int recipeId)
   {
    try
    {
      List<FavoriteAccount> favorites = _favoritesService.GetFavoritesByRecipeId(recipeId);
      return Ok(favorites);
    }
    catch (Exception e)
        {
            return BadRequest(e.Message);
        }
   }


}
