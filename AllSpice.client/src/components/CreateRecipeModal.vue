<template>
  <div v-if="!activeRecipe.id" class="modal" tabindex="-1" id="createRecipeModal">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Create Recipe</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <form @submit.prevent="createRecipe()">
          <div class="row modal-body">
            <div class="col-12">
              <label for="Recipe Name">Recipe Name</label>
              <input type="text" id="title" name="title" class="form-control" required minlength="5" maxlength="25" aria-label="Recipe Name" v-model="editable.title">
            </div>
            <div class="col-12">
              <label for="imgUrl" class="mt-2">Image URL</label>
              <input type="url" id="imgUrl" name="imgUrl" class="form-control" required minlength="5" maxlength="500" aria-label="Image U R L" v-model="editable.img">
            </div>
            <div class="col-12">
              <label for="category">Category</label>
              <select name="category" id="category" class="form-control" aria-label="Category" v-model="editable.category">
                <option value="Mexican">Mexican</option>
                <option value="Italian">Italian</option>
                <option value="Asian">Asian</option>
                <option value="Indian">Indian</option>
                <option value="Thai">Thai</option>
                <option value="Specialty Coffee">Specialty Coffee</option>
                <option value="Other">Other</option>
              </select>
            </div>
            <label for="instructions" class="mt-2">Instructions</label>
            <div class="col-12">
              <textarea  id="instructions" name="instructions" class="col-12" aria-label="Instructions" required minlength="5" maxlength="500"
              v-model="editable.instructions"></textarea>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" aria-label="Close">Cancel</button>
            <button type="submit" class="btn btn-danger" aria-label="Submit" data-bs-dismiss="modal" @click="openActiveRecipeModal()">Submit</button>
          </div>
        </form>
      </div>
    </div>
  </div>
  
</template>


<script>
import { computed, ref } from "vue"
import Pop from "../utils/Pop.js"
import { recipesService } from "../services/RecipesService.js"
import { AppState } from "../AppState.js"
import { Modal } from "bootstrap"
export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      activeRecipe: computed(()=> AppState.activeRecipe),

      openActiveRecipeModal() {
        Modal.getOrCreateInstance('#activeRecipeModal').show()
        },
      
      
      async createRecipe() {
        try {
          const formData = editable.value
          await recipesService.createRecipe(formData)
          editable.value = {}
        } catch (error) {
          Pop.error(error)
        }
      },

    }
  }
}
</script>


<style lang="scss" scoped></style>