<template>
    <section>
        <h2 class="text-center p-5 text-light">Alle soldater</h2>
        <section class="row mt-3">
            <soldier-item v-for="(soldier,i) in Soldiers" :key="i"
            
                :SoldierImage="soldier.soldierImage"
                :Id="soldier.id"
                :FirstName="soldier.firstName"
                :LastName="soldier.lastName"
                :Age="soldier.age"
                :Gender="soldier.gender"
                :Rank="soldier.rank"
                :specialSoldier="soldier.specialSoldier"
                :SoldierType="soldier.soldierType"
                
                ></soldier-item>
        </section>
    </section>
</template>

<script>
import SoldierService from '../../service/soldierService.js'
import SoldierItem from './SoldierItem.vue';
export default {
    setup() {
        const Soldiers = SoldierService.getAllSoldiers();

        return{
            Soldiers
        }
    },
    components: {
        SoldierItem,
    }
}
</script>


