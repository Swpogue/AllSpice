<template>
  <div class="col-12">
   <i @click="deleteIngredient()" class="mdi mdi-delete icon" aria-label="delete ingredient"></i> {{ ingredient.quantity }} {{ ingredient.name }}
  </div>
</template>



<script>
import { Ingredient } from "../models/Ingredient.js";
import { ingredientsService } from "../services/IngredientsService.js";
import Pop from "../utils/Pop.js";

export default {

  props: {
  ingredient: {type: Ingredient, required: true}
},

  setup(props){

    return {

      async deleteIngredient(){
        try {
          if (await Pop.confirm("You sure?")){
            const ingredientId = props.ingredient.id;
            await ingredientsService.deleteIngredient(ingredientId);
            // logger.log(ingredientId)
          }
        } catch (error) {
          Pop.error(error.message)
        }
      },
    }
  }
}
</script>


<style lang="scss" scoped>
  .icon{
  cursor: pointer;
}
</style>