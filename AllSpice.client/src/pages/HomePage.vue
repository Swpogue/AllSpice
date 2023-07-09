<template>
  <!-- <create-recipe-modal id="createRecipeModal"></create-recipe-modal> -->
  <section class="container-fluid">
    <div class="row justify-content-center">
      <div class="d-flex justify-content-around">
        <button @click="filterBy = ''" class="btn btn-outline-dark w-15">All Recipes</button>
        <button @click="filterBy = 'favorites'" class="btn btn-outline-dark w-15">My Favorites</button>
        <button @click="filterBy = 'myRecipe'" class="btn btn-outline-dark w-15">My Recipes</button>
        <!-- <button v-if="account.id" class="btn btn-outline-dark w-15" @click="openRecipeModal()">Create a Recipe</button> -->
      </div>
    </div>

    <div class="row">
      <div class="col-md-3 my-3 p-4" v-for="r in recipes" :key="r.id">
        <RecipeCard :recipes="r" />
      </div>
    </div>
  </Section>
</template>

<script>
import { computed, onMounted, ref} from "vue";
import RecipeCard from "../components/RecipeCard.vue";
import Pop from "../utils/Pop.js";
import { recipesService } from "../services/RecipesService.js"
import { AppState } from "../AppState.js";
// import { Modal } from "bootstrap";
import { logger } from "../utils/Logger.js";

export default {
  setup() {

    const filterBy = ref('')


    onMounted(() => { getRecipes(); });

    // watchEffect(()=> {
    //   if (AppState.recipes)
    //   getRecipes()
    // });

    async function getRecipes() {
      try {
        await recipesService.getRecipes();
      } catch (error) {
        Pop.error(error);
      }
    }


    return {
      
      filterBy,
      account: computed(() => AppState.account),
      recipes: computed(() => {
        if (!filterBy.value) {
          return AppState.recipes
        } else (filterBy.value == "myRecipe"); {
          logger.log('Recipe')
          return AppState.recipes.filter(r => r.creatorId == AppState.account.id)
        }
        // else if (filterBy.value == "favorites"){
          //   return AppState.myFavorites
          // }
        }),

        // openRecipeModal() {
        //   Modal.getOrCreateInstance('#createRecipeModal').show()
        // },

    };
  },
  components: { RecipeCard, }
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
