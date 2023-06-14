<template>
    <h2 class="text-center fw-bold p-5 bg text-light">Velkomen til våpen siden</h2>
    <div class="container">
        <weapon-list></weapon-list>
    </div>
</template>

<script>
import WeaponList from '../components/weapon/WeaponList.vue'
export default {
    setup() {
        
    },
    components: {
        WeaponList,
    }
}
</script>

