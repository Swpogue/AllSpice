import { AppState } from "../AppState.js"
import { Recipe } from "../models/Recipe.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class RecipesService{

  async getRecipes(){
    const res = await api.get('api/recipes')
    logger.log(res.data)
    AppState.recipes = res.data.map(r => new Recipe(r))
    logger.log('RECIPES', res.data)
  }

  async deleteRecipe(recipeId){
    const res = await api.delete(`api/recipes/${recipeId}`)
    const rIndex = AppState.recipes.findIndex(r=> r.id == recipeId)
    AppState.recipes.splice(rIndex, 1)
    logger.log(res.data)

  }

  async createRecipe(formData){
    const res = await api.post(`api/recipes`, formData)
    return res.data
  }

  async activeRecipeById(recipeId){
    AppState.activeRecipe = AppState.recipes.find(r => r.id == recipeId)
    logger.log("Active Recipe", AppState.activeRecipe)

  }

}

export const recipesService = new RecipesService()