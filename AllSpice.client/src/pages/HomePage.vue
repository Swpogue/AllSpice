<template>

  <Section class="container-fluid">
    <div class="row">
      <div class="col-md-3 my-3 p-4" v-for="r in recipes" :key="r.id">
        <RecipeCard :recipes="r" />
      </div>
    </div>
    
  </Section>
</template>

<script>
import { computed, onMounted } from "vue";
import RecipeCard from "../components/RecipeCard.vue";
import Pop from "../utils/Pop.js";
import {recipesService} from "../services/RecipesService.js"
import { AppState } from "../AppState.js";

export default {
    setup() {
      onMounted(()=> {getRecipes();});

      async function getRecipes(){
        try {
          await recipesService.getRecipes();
        } catch (error) {
          Pop.error(error);
        }
      }


        return {
          recipes: computed(()=> AppState.recipes),
        };
    },
    components: { RecipeCard }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
