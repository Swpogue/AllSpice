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
        Favorite favorite = GetById(favoriteId);
        if (favorite.AccountId != userId) new Exception("Unauthorized to remove.!");
        int rows = _repo.DeleteFavorite(favoriteId);
        if (rows > 1) new Exception("WHAT went wrong?");
    }

    private Favorite GetById(int favoriteId)
    {
      Favorite favorite = _repo.GetById(favoriteId);
      if (favorite == null) new Exception("No Id Here!");
      return favorite;
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