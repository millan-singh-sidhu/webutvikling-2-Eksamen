<template>

    <router-link to="/admin">
        <input class="btn btn-light m-2 fs-5" type="button" value="Tilbake til admin side">
    </router-link>

    <section class="container">
        <div class="text-center p-5 bg text-light rounded mb-5">
            <h3>Her kan du bånde endre, slette og legge til soldater <i class="bi bi-pen-fill"></i></h3>
            <p>husk å laste siden inn på nytt etter du har lagt til eller slettet en soldat. sletting funker ved å velge id til soldaten</p>   
        </div>
        <div class="form-floating mb-3 input-group">  
            <input class="form-control" v-model="id" type="text" placeholder="1">
            <label>id:</label>  
            <input class="btn btn-light fs-5" @click="getSoldierById" type="button" value="Hent soldat">
        </div>
        <div>
            <label class="text-light mb-1">Velg bilde under: </label>
            <input class="form-control" @change="setSoldierImage" type="file">
        </div>
        <div class="form-floating my-3">
            <input class="form-control" v-model="firstName" type="text" placeholder="Fornavn">
            <label>Fornavn: </label>
        </div>
        <div class="form-floating mb-3">
            <input class="form-control" v-model="lastName" type="text" placeholder="Etternavn">
            <label>Etternavn :</label>
        </div>
        <div class="form-floating mb-3">
            <input class="form-control" v-model="age" type="number" placeholder="18">
            <label>Alder: </label>
        </div>
        <div class="form-floating mb-3">
            <select class="form-select" v-model="gender">  
                <option value="Mann">Mann</option>
                <option value="Kvinne">Kvinne</option>
            </select>
            <label>Kjønn: </label>
        </div>
        <div class="form-floating mb-3">
            <select class="form-select" v-model="rank">
                <option value="Meinig">Meinig</option>
                <option value="Visekorporal">Visekorporal</option>
                <option value="Sersjant">Sersjant</option>
                <option value="Fenrik">Fenrik</option>
                <option value="Løytnant">Løytnant</option>
                <option value="Kaptein">Kaptein</option>
                <option value="Major">Major</option>
                <option value="General">General</option>
            </select>
            <label>Militær grad: </label>
        </div>
        <div class="form-floating mb-3">
            <select class="form-select" v-model="specialSoldier">
                <option value="true">spesial soldat</option>
                <option value="false">vanlig soldat</option>
            </select>
            <label>spesial soldat: </label>
        </div>
        <div class="form-floating mb-3">
            <input class="form-control" v-model="soldierType" type="text" placeholder="infanterist">
            <label>Soldat type: </label>
        </div>
        
        <input class="btn btn-light my-2 fs-5" @click="editSoldier" type="button" value="Endre soldat info">
        <input class="btn btn-light ms-3 fs-5" @click="postSoldier" type="button" value="Legg til soldat">
        <input class="btn btn-light ms-3 fs-5" @click="deleteSoldier" type="button" value="Slett soldat">

    </section>
    
    <section>
        <div class="container">
            <soldier-list></soldier-list>   
        </div>
        
    </section>

    
</template>

<script>
import { reactive, toRefs } from 'vue'
import soldierService from '../../service/soldierService.js'
import SoldierList from "../soldier/SoldierList.vue"

export default {
    setup() {

        const image = new FormData();

        //soldierFrom er koblet mot v-model over.
        const soldierFrom = reactive({
            id:"",
            soldierImage: "" ,
            firstName: "" ,
            lastName: "" ,
            age: "" ,
            gender: "" ,
            rank: "" ,
            specialSoldier: "" ,
            soldierType: ""
        });

        const setSoldierImage = (e) => {
            image.append("file", e.target.files[0]);
            soldierFrom.soldierImage = e.target.files[0].name;
            
            
        }
        //henter soldater etter id og fyller ut input feltene med infomasjonen
        const getSoldierById = async () => {
            const soldier = await soldierService.getById(soldierFrom.id);
            soldierFrom.soldierImage = soldier.soldierImage;
            soldierFrom.firstName = soldier.firstName;
            soldierFrom.lastName = soldier.lastName;
            soldierFrom.age = soldier.age;
            soldierFrom.gender = soldier.gender;
            soldierFrom.rank = soldier.rank;
            soldierFrom.specialSoldier = soldier.specialSoldier;
            soldierFrom.soldierType = soldier.soldierType;

        }

        //denne skal endre på soldater
        const editSoldier = async () => {
            
            const editedSoldier = {
                id: parseInt(soldierFrom.id),
                soldierImage: soldierFrom.soldierImage ,
                firstName: soldierFrom.firstName ,
                lastName: soldierFrom.lastName ,
                age: parseInt(soldierFrom.age) ,
                gender: soldierFrom.gender ,
                rank: soldierFrom.rank ,
                specialSoldier: JSON.parse(soldierFrom.specialSoldier) ,
                soldierType: soldierFrom.soldierType
            }
            soldierService.PutSoldier(editedSoldier)
            alert(`${soldierFrom.firstName} ${soldierFrom.lastName} med id: ${soldierFrom.id} har blit endret`)
            resetSoldierInput();        
        }

        //denne legger til soldater
        const postSoldier = () => {
            const newSoldier = {
                soldierImage: soldierFrom.soldierImage ,
                firstName: soldierFrom.firstName ,
                lastName: soldierFrom.lastName ,
                age: parseInt(soldierFrom.age) ,
                gender: soldierFrom.gender ,
                rank: soldierFrom.rank ,
                specialSoldier: JSON.parse(soldierFrom.specialSoldier) ,
                soldierType: soldierFrom.soldierType
            }
            
            soldierService.postSoldier(newSoldier , image )
            alert(`${soldierFrom.firstName} ${soldierFrom.lastName} har blitt lagt til. Husk å laste siden inn siden på nytt for å se endringen`)
            resetSoldierInput(); 
        }

        //sletter soldater
        const deleteSoldier = async () => {
            let soldierId = parseInt(soldierFrom.id)
            soldierService.deleteSoldier(soldierId);
            alert(`soldat ${soldierFrom.firstName} ${soldierFrom.lastName} med id: ${soldierId} har blitt slettet. Husk å laste siden inn på nytt for å se endringen`)
            resetSoldierInput(); 
        }

        //denne bruker jeg til å tømme input feltene for infomasjon etter du har trykket på knappene
        const resetSoldierInput = () =>{
            soldierFrom.id = "",
            soldierFrom.soldierImage = "", 
            soldierFrom.firstName = "",
            soldierFrom.lastName = "",
            soldierFrom.age = "",
            soldierFrom.gender = "",
            soldierFrom.rank = "",
            soldierFrom.specialSoldier = "",
            soldierFrom.soldierType = ""
        }

        return {
            getSoldierById,
            editSoldier,
            setSoldierImage,
            postSoldier,
            deleteSoldier,
            resetSoldierInput,
            ...toRefs( soldierFrom )
            }
    },
    components:{
        SoldierList
    }
}
</script>

