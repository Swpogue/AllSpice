<template>
  <header class="container-fluid">
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
   <footer class="bg-dark text-light">
   
  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root{
  --main-height: calc(100vh - 32px - 64px);
}

header{
  height: 550px;
}

footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
