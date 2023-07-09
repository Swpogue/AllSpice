<template>
    <div class="modal" tabindex="-1">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Recipe: {{ recipes.title }}</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div>
        </div>
        <form @submit.prevent="createIngredients()">
          <div class="row modal-body">
            <img class="rounded-top" :src="recipes.img" :alt="recipes.title">
       
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" aria-label="Close">Cancel</button>
            <button type="submit" class="btn btn-danger" data-bs-dismiss="modal" aria-label="Submit">Submit</button>
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

      recipes: computed(()=> AppState.recipes)

    }
  }
}
</script>


<style lang="scss" scoped>

</style>