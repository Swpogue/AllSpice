import { Recipe } from "./Recipe.js"

export class Favorite{
    constructor(data){
        this.id = data.id
        this.recipeId = data.recipeId
        this.accountId = data.accountId
    }
}

// Favorite Recipe for account
export class MyFavorite extends Recipe{
    constructor(data){
        super(data)
        this.favoriteId = data.favoriteId
    }
}