namespace AllSpice.Services
{
  public class FavoritesService
    {
        private readonly FavoritesRepository _repo;

    public FavoritesService(FavoritesRepository repo)
    {
      _repo = repo;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
      Favorite newFav = _repo.CreateFavorite(favoriteData);
      return newFav;
    }

    internal void DeleteFavorite(int favoriteId, string userId)
    {
      
        int rows = _repo.DeleteFavorite(favoriteId);
        if (rows > 1) new Exception("Something went wrong");
    }

    internal List<FavoriteAccount> GetFavoritesByRecipeId(int recipeId)
    {
      return _repo.GetFavoritesByRecipeId(recipeId);
    }

    internal List<FavoriteRecipe> GetMyFavoriteRecipes(string accountId)
    {
        List<FavoriteRecipe> myFavs = _repo.GetMyFavoriteRecipes(accountId);
        return myFavs;
    }
  }
}