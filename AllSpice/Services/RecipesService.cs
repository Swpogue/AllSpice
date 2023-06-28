namespace AllSpice.Services
{
  public class RecipesService
    {
        private readonly IDbConnection _db;
        public RecipesService(IDbConnection db)
    {
      _db = db;
    }
  }
}