import { AppState } from "../AppState.js"
import { Favorite } from "../models/Favorite.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class FavoritesService{
async createFavorite(favoriteData){
  const res = await api.post(`/api/favorites`, favoriteData)
  AppState.favorites.push(new Favorite(res.data))

}
async getFavoriteByRecipeId(recipeId){
const res = await api.get(`api/recipes/${recipeId}/favorites`)
AppState.favorites = res.data.map(t => new Favorite(t))
logger.log('GETTING Favorites', res.data)
}
}

export const favoritesService = new FavoritesService()