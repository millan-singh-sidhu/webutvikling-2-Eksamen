<template>
    <section>
        <h2 class="text-center p-5 text-light">Alle våpen</h2>
        <section class="row mt-3">
            <weapon-item v-for="(weapon,i) in Weapons" :key="i"

                :WeaponImage="weapon.weaponImage"
                :WeaponName="weapon.weaponName"
                :Id="weapon.id"
                :weaponType="weapon.weaponType"
                :AmmoCapacity="weapon.ammoCapacity"
                :AmmoType="weapon.ammoType"
                :Automatic="weapon.automatic"
                :SemiAutomatic="weapon.semiAutomatic"
                :SingelFire="weapon.singelFire"
                
            ></weapon-item>
        </section>
    </section>
</template>

<script>
import weaponService from '../../service/weaponService.js'
import WeaponItem from './WeaponItem.vue'
export default {
    setup() {
        const Weapons = weaponService.getAllWeapons();

        return{
            Weapons
        }
    },
    components: {
        WeaponItem,
    }
}
</script>