<template>

    <div class="text-center text-light p-5 m-auto bg">
        <h2 class="fw-bold ">Velkomen til Admin siden</h2>
        <p class=" fs-4">Velg hva du ønsker å gjøre</p>

    <router-link to="/edit-soldier">
        <input class="btn btn-light m-2 fs-5" type="button" value="endre/legge til soldater">
    </router-link>

    <router-link to="/edit-weapon">
        <input class="btn btn-light m-2 fs-5" type="button" value="endre/legge til våpen">
    </router-link>
    
    <section>
        <router-view></router-view>
    </section>
    
    </div>
</template>


<script>

export default {
    setup() {
        
    },
    components: {
        
        
    }
}
</script>


