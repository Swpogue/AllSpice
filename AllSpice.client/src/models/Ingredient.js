export class Ingredient{
  constructor(data){
    this.id = data.id
    this.name = data.name
    this.quantity = data.quantity
    this.recipe = data.recipe
    this.recipeId = data.recipeId
  }
}