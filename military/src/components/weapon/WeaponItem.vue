<template>
    <article class="col-12 col-md-6 col-lg-4 p-2">
        <div class="p-2 card mx-auto bg-light">
            <img class="card-img-top" :src="`https://localhost:7262/images/WeaponImage/${WeaponImage}` " >
            <div class="card-body">
                <h2 class="card-title text-center">Våpen navn: {{WeaponName}}</h2>
                <p class="card-text fs-4">Våpen id: {{Id}}</p>
                <p class="card-text fs-4">Våpen type: {{weaponType}}</p>
                <p class="card-text fs-4">Ammunisjons kapasitet: {{AmmoCapacity}}</p>
                <p class="card-text fs-4">Ammunisjons typer: {{AmmoType}}</p>
                <p class="card-text fs-4">Av fyrings typer: 
                    Automatisk: {{Automatic}}, <br>
                    Semi automatisk: {{SemiAutomatic}},<br>
                    Enkel skudd: {{SingelFire}}</p>
            </div>
        </div>
    </article>
</template>



<script>
export default {
    setup() {
        
    },
    props: {
        Id:Number,
        WeaponImage:String,
        WeaponName:String,
        weaponType:String,
        AmmoCapacity: Number,
        AmmoType:String,
        Automatic:Boolean,
        SemiAutomatic:Boolean,
        SingelFire:Boolean,

    },
}
</script>

