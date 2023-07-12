import { AppState } from "../AppState.js"
import { Ingredient } from "../models/Ingredient.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class IngredientsService{

  async getIngredientsByRecipeId(recipeId){
    const res = await api.get(`api/recipes/${recipeId}/ingredients`)
    logger.log('INGREDIENTS!',res.data )
    AppState.ingredients = res.data.map(i => new Ingredient(i))
    logger.log('NEW Ingredient', res.data)
  }

  async createIngredient(formData){
    formData.recipeId = AppState.activeRecipe.id
    const res = await api.post(`api/ingredients`, formData)
    AppState.ingredients.unshift(new Ingredient(res.data))
    logger.log(res.data)
  }

}

export const ingredientsService = new IngredientsService()