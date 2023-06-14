<template>
    <h2 class="text-center fw-bold p-5 bg text-light">Velkomen til soldat siden</h2>
    <div class="container">
        <soldier-list></soldier-list>
    </div>
</template>

<script>
import SoldierList from '../components/soldier/SoldierList.vue'
export default {
    setup() {
        
    },
    components: {
        SoldierList,
        
    }
}
</script>

