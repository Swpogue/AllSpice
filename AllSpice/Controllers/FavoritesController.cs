namespace AllSpice.Controllers;

  [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoritesService _favoritesService;
        private readonly Auth0Provider _auth;

    public FavoritesController(FavoritesService favoritesService, Auth0Provider auth)
    {
      _favoritesService = favoritesService;
      _auth = auth;
    }
  
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite favoriteData)
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                favoriteData.AccountId = userInfo.Id;
                Favorite newfav = _favoritesService.CreateFavorite(favoriteData);
                return Ok(newfav);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{favoriteId}")]
        [Authorize]
        public async Task<ActionResult<string>> DeleteFavorite(int favoriteId)
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                _favoritesService.DeleteFavorite(favoriteId, userInfo.Id);
                return Ok("Favorite removed.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }