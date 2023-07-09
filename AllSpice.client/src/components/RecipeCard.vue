<template>
  <recipe-details id="activeRecipeModal"></recipe-details>
    <div class="rounded elevation-5">
      <img @click="activeRecipeById()" class="rounded-top" :src="recipes.img" :alt="recipes.title">
      <div class="text-center p-2 rounded-bottom text-black fw-bold">
        <p class="m-0">Category: {{ recipes.category }}</p>
        <p class="m-0">Recipe: {{ recipes.title }}</p>
        <p>Created by: {{ recipes.creator.name }}</p>
        <!-- TODO put Favorites here  -->
        <p class="m-0 fs-4 justify-content-between d-flex">{{}}<i @click="f" class="mdi mdi-heart ps-2 icon" aria-label="Favorite"></i><i @click="deleteRecipe" class="mdi mdi-delete icon" aria-label="delete"></i></p>
      </div>
    </div>
</template>


<script>
import { Modal } from "bootstrap";
import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { recipesService } from "../services/RecipesService.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import RecipeDetails from "./RecipeDetails.vue";
import { computed, ref } from "vue";

export default {
  components: { RecipeDetails },
  props: {
    recipes: {type: Recipe, required: true}
  },

  setup(props){
    const modal = ref(null)

    return {
      modal,
      recipe: computed(()=> AppState.activeRecipe),

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
      },

      async activeRecipeById(recipeId){
        try {
          await recipesService.activeRecipeById(recipeId)
          modal.value = new Modal(document.getElementById('activeRecipeModal'))
          Modal.getOrCreateInstance('#activeRecipeModal').show()
        } catch (error) {
          Pop.error(error)
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
    cursor: pointer;
  }
  .icon{
  cursor: pointer;
}
</style>