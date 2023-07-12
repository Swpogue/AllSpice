<template>
    <div class="modal" tabindex="-1">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h4 class="modal-title col-10">Recipe: {{ recipe.title }}</h4>
          <button type="button" class="btn-close col-1" data-bs-dismiss="modal" aria-label="Close" @click="clearActive()"></button>
        </div>
        <div class="row p-1">
          <h5>Category: {{ recipe.category }}</h5>
          <h5>Instructions: <span>{{ recipe.instructions }}</span></h5>
          <p class="col-12"></p>
          <img class="rounded-top" :src="recipe.img" :alt="recipe.title">
          <div class="col-md-12 my-1 ps-3" v-for="i in ingredient" :key="i.id">
          <IngredientCard  :ingredient="i"/>
          </div>
        </div>
        <form @submit.prevent="createIngredient()">
          <div class="row modal-body">
            <div class="col-12">
              <label for="quantity" class="mt-2">Quantity and Measurement</label>
              <input type="text" id="quantity" name="quantity" class="form-control" required minlength="1" maxlength="10" aria-label="Ingredient quantity" v-model="editable.quantity">
              <label for="ingredient name" class="mt-2">Ingredient</label>
              <input type="text" id="ingredient" name="ingredient name" class="form-control" required minlength="5" maxlength="500" aria-label="Ingredient name" v-model="editable.name">
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" aria-label="Close" @click="clearActive()">Cancel</button>
            <button type="submit" class="btn btn-danger" aria-label="Submit">Submit</button>
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
import IngredientCard from "./IngredientCard.vue";
import { Ingredient } from "../models/Ingredient.js";
export default {
  components: { IngredientCard },
  setup(){
    const editable = ref({});
    const route = useRoute();


 

    return {
      editable,

      recipe: computed(()=> AppState.activeRecipe),
      ingredient: computed(()=> AppState.ingredients),
      


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
    height: 30vh;
    width: 100%;
    object-fit: cover;
  }

</style>