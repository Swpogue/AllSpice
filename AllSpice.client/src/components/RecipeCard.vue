<template>
    <div class="rounded elevation-5">
      <img class="rounded-top" :src="recipes.img" :alt="recipes.title">
      <div class="text-center p-2 rounded-bottom text-black fw-bold">
        <p class="m-0">Category: {{ recipes.category }}</p>
        <p class="m-0">Recipe: {{ recipes.title }}</p>
        <!-- TODO put Favorites here  -->
        <p class="m-0">{{ recipes.favorites}}<i class="mdi mdi-heart ps-2"></i></p>
      </div>
    </div>
</template>


<script>
import { Recipe } from "../models/Recipe.js";

export default {
  props: {
    recipes: {type: Recipe, required: true}
  },
  setup(){
    return {}
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