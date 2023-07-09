<template>
  <div class="row">
    <div class="col-md-12 bgImg image-fluid d-flex justify-content-end">

      <div class="col-md-1">
        <!-- LOGIN COMPONENT HERE -->
        <Login />
      </div>
    </div>
   
  </div>
</template>

<script>
import Login from './Login.vue';
export default {
  setup() {
    return {}
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.bgImg{
  background-image: url(../assets/img/bgImg2.png);
  height: 50vh;
  width: 100%;
  background-size: cover;
  object-position: center;
  background-repeat: no-repeat;
}
.nav-link {
  text-transform: uppercase;
}

</style>
