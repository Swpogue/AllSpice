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
          
        </div>
        <form @submit.prevent="createIngredients()">
          <div class="row modal-body">
       
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" aria-label="Close" @click="clearActive()">Cancel</button>
            <button type="submit" class="btn btn-danger" data-bs-dismiss="modal" aria-label="Submit" @click="clearActive()">Submit</button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from "vue";

import { AppState } from "../AppState.js";
export default {
  setup(){
    return {

      recipe: computed(()=> AppState.activeRecipe),

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