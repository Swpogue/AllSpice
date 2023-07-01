namespace AllSpice.Repositories;

public class FavoritesRepository
    {
        private readonly IDbConnection _db;

  public FavoritesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Favorite CreateFavorite(Favorite favoriteData)
  {
           string sql = @"
        INSERT INTO favorites
        (accountId, recipeId)
        VALUES
        (@accountId, @recipeId);
        SELECT LAST_INSERT_ID();
        ";
        int lastInsertId = _db.ExecuteScalar<int>(sql, favoriteData);
        favoriteData.Id = lastInsertId; 
        return favoriteData;
  }

  internal int DeleteFavorite(int favoriteId)
  {
           string sql = @"
        DELETE FROM favorites
        WHERE id = @favoriteId
        LIMIT 1
        ;";
        int rows = _db.Execute(sql, new { favoriteId });
        return rows;
  }

  internal List<FavoriteAccount> GetFavoritesByRecipeId(int recipeId)
  {
    string sql = @"
    SELECT
    favs.*
    act.*
    FROM favorites favs
    JOIN accounts act ON act.id = favs.accountId
    WHERE favs.recipeId = @recipeId;
    ";

    List<FavoriteAccount> favorite = _db.Query<FavoriteAccount, Account, FavoriteAccount>(sql, (favorite, account) =>
    {
        favorite.Id = account.Id;
        return favorite;

    },new {recipeId}).ToList();
    return favorite;
  }

  internal List<FavoriteRecipe> GetMyFavoriteRecipes(string accountId)
  {
        string sql = @"
        SELECT
        favs.*,
        recipes.*,
        act.*
        FROM favorites favs
        JOIN recipes ON recipes.id= favs.recipeId
        JOIN accounts act ON act.id = recipes.creatorId
        WHERE favs.accountId = @accountId

        ;";
        List<FavoriteRecipe> myFavs = _db.Query<Favorite, FavoriteRecipe, Account, FavoriteRecipe>(sql, (fav, recipe, account) =>
        {
            recipe.FavId = fav.Id;
            recipe.Creator = account;
            return recipe;
        }, new { accountId }).ToList();
        return myFavs;
  }
}
