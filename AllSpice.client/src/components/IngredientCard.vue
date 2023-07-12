<template>
  <div class="col-12">
    {{ ingredient.quantity }} {{ ingredient.name }}
  </div>
</template>



<script>
import { Ingredient } from "../models/Ingredient.js";
import { ingredientsService } from "../services/IngredientsService.js";

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

</style>