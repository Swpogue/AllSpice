<template>
    <div class="rounded elevation-5">
      <img class="rounded-top" :src="recipes.img" :alt="recipes.title">
      <div class="text-center p-2 rounded-bottom text-black fw-bold">
        <p class="m-0">Category: {{ recipes.category }}</p>
        <p class="m-0">Recipe: {{ recipes.title }}</p>
        <!-- TODO put Favorites here  -->
        <p class="m-0 fs-4 justify-content-between d-flex">{{}}<i @click="favorite" class="mdi mdi-heart ps-2"></i><i @click="deleteRecipe" class="mdi mdi-delete"></i></p>
      </div>
    </div>
</template>


<script>
import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { recipesService } from "../services/RecipesService.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";

export default {
  props: {
    recipes: {type: Recipe, required: true}
  },
  setup(props){
    return {

      async deleteRecipe(){

        try {
          if (await Pop.confirm("You sure?")){
            const recipeId = props.recipes.id;
            await recipesService.deleteRecipe(recipeId);
            // logger.log(recipeId)
          }
        } catch (error) {
          Pop.error(error.message)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
  img {
    height: 30vh;
    width: 100%;
    object-fit: cover;
  }
</style>