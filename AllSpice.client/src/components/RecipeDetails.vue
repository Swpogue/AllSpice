<template>
    <div class="modal container-fluid" tabindex="-1">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header row">
          <h4 class="modal-title col-10">Recipe: {{ recipe.title }}</h4>
          <button type="button" class="btn-close col-1" data-bs-dismiss="modal" aria-label="Close" @click="clearActive()"></button>
        </div>
        <div class="row p-1">
          <h5>Category: {{ recipe.category }}</h5>
          <h5>Instructions: <span>{{ recipe.instructions }}</span></h5>
          <p class="col-12"></p>
          <img class="rounded-top" :src="recipe.img" :alt="recipe.title">
          <div>{{ ingredients }}</div>
          
        </div>
        <form @submit.prevent="createIngredient()">
          <div class="row modal-body">
            <label for="ingredients" class="mt-2">Add Ingredients</label>
              <input type="url" id="ingredients" name="ingredients" class="form-control" required minlength="5" maxlength="500" aria-label="Ingredients" v-model="editable.ingredients">
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" aria-label="Close" @click="clearActive()">Cancel</button>
            <button type="submit" class="btn btn-danger" data-bs-dismiss="modal" aria-label="Submit" @click="createIngredient()">Submit</button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>


<script>
import { computed, onMounted, ref, watchEffect } from "vue";
import { ingredientsService} from "../services/IngredientsService.js"
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { useRoute } from "vue-router";
export default {
  setup(){
    const editable = ref({});
    const route = useRoute();

    // onMounted(()=> { getIngredientsByRecipeId(); });

 

    return {
      editable,

      recipe: computed(()=> AppState.activeRecipe),
      ingredients: computed(()=> AppState.ingredients),
      


      async createIngredient(){
        try {
          const formData = editable.value
          formData.recipeId = route.params.id;
          await ingredientsService.createIngredient(formData)
          editable.value = {}
        } catch (error) {
          Pop.error(error)
        }

      },

      clearActive(){
        AppState.activeRecipe = {}
      }

    }
  }
}
</script>


<style lang="scss" scoped>
 img {
    height: 50vh;
    width: 100%;
    object-fit: cover;
  }

</style>