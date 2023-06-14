<template>
  <div>
    <military-navbar></military-navbar>
  </div>
  <router-view></router-view>
</template>

<script>
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap-icons/font/bootstrap-icons.css'

import MilitaryNavbar from './components/shared/MilitaryNavbar.vue'
export default {
  name: 'App',
  components: {
    MilitaryNavbar,
  }
}
</script>
<!-- style som skal gå gjenom alle filer er her-->
<style>
body{
  background-color: rgb(66, 74, 81);
}

.bg{
    background-color: #3a6ef3;
}

</style>
