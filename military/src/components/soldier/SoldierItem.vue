<template>
    <article class="col-12 col-md-6 col-lg-4 p-2">
        <div class="p-2 card mx-auto bg-light">
            <img class="card-img-top" :src="`https://localhost:7262/images/SoldierImage/${SoldierImage}`">
            <div class="card-body">
                <h2 class="card-title text-center">{{FirstName}} {{LastName}}</h2>
                <p class="card-text fs-4">Soldat id: {{Id}}</p>
                <p class="card-text fs-4">Alder: {{Age}}</p>
                <p class="card-text fs-4">Kjønn: {{Gender}}</p>
                <p class="card-text fs-4">Soldat grad: {{Rank}} </p> 

                <div v-if="specialSoldier === true" class="mb-2 border rounded text-center SpacialSoldier">
                    <p class="card-text fs-4" >Dette er en spesial soldat</p>
                </div>

                <div v-else class="mb-2 border rounded text-center NormalSoldier" >
                    <p class="card-text fs-4" >Dette er en vanlig soldat</p>
                </div>
                <p class="card-text fs-4">soldat type: {{SoldierType}}</p>
            </div>
        </div>
    </article>
</template>

<script>
export default {
    setup() {
        
    },
    props: {
        SoldierImage: String,
        Id:Number,
        FirstName: String,
        LastName: String,
        Age: Number,
        Gender: String,
        Rank: String,
        specialSoldier: Boolean,
        SoldierType:String

    }
}
</script>

<style scoped>

.SpacialSoldier{
    background-color: rgb(113, 217, 122);
}
.NormalSoldier{
    background-color: rgb(255, 234, 99);
}
</style>

