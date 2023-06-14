<template>
    <router-link to="/admin">
        <input class="btn btn-light m-2 fs-5" type="button" value="Tilbake til admin side">
    </router-link>

    <!--husk å lega kommentar om hvordan du bruker siden som at du må refreshe siden etter du har lagt til ting--> 
    <section class="container">
        <div class="text-center p-5 bg text-light rounded mb-5">
            <h3>Her kan du bånde endre, slette og legge til våpen <i class="bi bi-pen-fill"></i></h3>
            <p>Husk å laste siden inn på nytt etter du har lagt til eller slettet et Våpen. Sletting funker ved å velge id til våpenet</p>
        </div>

        <div class="form-floating mb-3 input-group">
            
            <input class="form-control" v-model="id" type="text" placeholder="1">
            <label>Id: </label>
            <input class="btn btn-light fs-5" @click="getWeaponById" type="button" value="hent våpen">
        </div>
        <div>
            <label class="text-light mb-1">Hent bilde: </label>
            <input class="form-control" @change="setWeaponImage" type="file">
        </div>
        <div class="form-floating my-3">
            <input class="form-control" v-model="weaponName" type="text" placeholder="Glock">
            <label>Våpen navn: </label>
        </div>
        <div class="form-floating mb-3">
             <select class="form-select" v-model="weaponType">  
                <option value="Angrepsrifle">Angrepsrifle</option>
                <option value="Håndvåpen">Håndvåpen</option>
                <option value="Maskinpistol">Maskinpistol</option>
                <option value="Skrapskytterrifle">Skrapskytterrifle</option>
                <option value="Maskingevær">Maskingevær</option>
            </select>
            <label >Våpen type</label>
        </div>
         <div class="form-floating mb-3">
            <input class="form-control" v-model="ammoCapacity" type="number" placeholder="0">
            <label>Ammunisjons kapasitet: </label>
        </div>
        <div class="form-floating mb-3">
            <input class="form-control" v-model="ammoType" type="text" placeholder="0mm">
            <label>Ammunisjons type: </label>
        </div>
        <div>
            <label class="text-light mb-1"> Våpenets av fyrings typer: </label>

            <div class="form-floating mb-3">
                <select class="form-select" v-model="automatic">
                    <option value="true">true</option>
                    <option value="false">false</option>
                </select>
                <label>Automatisk: </label>
            </div>

            <div class="form-floating mb-3">
                <select class="form-select" v-model="semiAutomatic">
                    <option value="true">true</option>
                    <option value="false">false</option>
                </select>
                <label>Semi automatisk: </label>
            </div>
            
            <div class="form-floating mb-3">
                <select class="form-select" v-model="singelFire">
                    <option value="true">true</option>
                    <option value="false">false</option>
                </select>
                <label>Enkel skudd: </label>
            </div>
            
            
        </div>
        <input class="btn btn-light my-2 fs-5" @click="editWeapon" type="button" value="Oppdater våpen info">
        <input class="btn btn-light ms-3 fs-5" @click="postWeapon" type="button" value="Legg til våpen">
        <input class="btn btn-light ms-3 fs-5" @click="deleteWeapon" type="button" value="Slett våpen">
    </section>
    <section>
        <div class="container">
            <weapon-list></weapon-list>
        </div>
        
    </section>
</template>

<script>
import { reactive, toRefs} from 'vue'
import weaponService from '../../service/weaponService.js'
import weaponList from '../weapon/WeaponList.vue'
export default {
    setup() {
        const image = new FormData();
        
        //weaponFrom er koblet mot v-model over
        const weaponFrom = reactive({
            id:"",
            weaponImage:"",
            weaponName:"",
            weaponType:"",
            ammoCapacity:"",
            ammoType:"",
            automatic:"",
            semiAutomatic:"",
            singelFire:""
        });

        const setWeaponImage = (e) => {
            image.append("file", e.target.files[0]);
            weaponFrom.weaponImage = e.target.files[0].name;
        }

        //henter våpen etter id og fyller ut input feltene med infomasjonen
        const getWeaponById = async () => {
            const weapon = await weaponService.getById(weaponFrom.id);
            weaponFrom.weaponImage = weapon.weaponImage;
            weaponFrom.weaponName = weapon.weaponName;
            weaponFrom.weaponType = weapon.weaponType
            weaponFrom.ammoCapacity = weapon.ammoCapacity;
            weaponFrom.ammoType = weapon.ammoType;
            weaponFrom.automatic = weapon.automatic;
            weaponFrom.semiAutomatic = weapon.semiAutomatic;
            weaponFrom.singelFire = weapon.singelFire;
        }
        //denne skal endre på våpen
        const editWeapon = async () => {
            const editedweapon = {
                id: parseInt(weaponFrom.id),
                weaponImage: weaponFrom.weaponImage,
                weaponName: weaponFrom.weaponName,
                weaponType: weaponFrom.weaponType,
                ammoCapacity: parseInt(weaponFrom.ammoCapacity),
                ammoType: weaponFrom.ammoType,
                automatic: JSON.parse(weaponFrom.automatic),
                semiAutomatic: JSON.parse(weaponFrom.semiAutomatic),
                singelFire: JSON.parse(weaponFrom.singelFire)
            }
            weaponService.putWeapon(editedweapon)
            alert(`${weaponFrom.weaponName} med id: ${weaponFrom.id} her blit endret på. Husk å laste siden inn på nytt for å se endringen`)
            resetWeaponInput();
        }

        //legger til våpen
        const postWeapon = () => {
            const newWeapon = {
                weaponImage: weaponFrom.weaponImage,
                weaponName: weaponFrom.weaponName,
                weaponType: weaponFrom.weaponType,
                ammoCapacity: parseInt(weaponFrom.ammoCapacity),
                ammoType: weaponFrom.ammoType,
                automatic: JSON.parse(weaponFrom.automatic),
                semiAutomatic: JSON.parse(weaponFrom.semiAutomatic),
                singelFire: JSON.parse(weaponFrom.singelFire)
            }
            weaponService.postWeapon(newWeapon, image)
            alert(`${weaponFrom.weaponName} har blitt lagt til. Husk å laste siden inn på nytt for å se endringen`)
            resetWeaponInput();
        }

        //sletter våpen
        const deleteWeapon = async () => {
            let weaponId = parseInt(weaponFrom.id)
            weaponService.deleteWeapon(weaponId)
            alert(`våpen ${weaponFrom.weaponName} med id: ${weaponId} har blitt slettet. Husk å laste siden inn på nytt for å se endringen`)
        }

        //denne bruker jeg til å tømme input feltene for infomasjon etter du har trykket på knappene
        const resetWeaponInput = () =>{
            weaponFrom.id ="",
            weaponFrom.weaponImage = "",
            weaponFrom.weaponName = "",
            weaponFrom.weaponType = "",
            weaponFrom.ammoCapacity = "",
            weaponFrom.ammoType = "",
            weaponFrom.automatic = "",
            weaponFrom.semiAutomatic = "",
            weaponFrom.singelFire = ""
        }

        return{
            setWeaponImage,
            getWeaponById,
            editWeapon,
            postWeapon,
            deleteWeapon,
            resetWeaponInput,
            ...toRefs(weaponFrom)
        }
    },
    components:{
        weaponList
    }
}
</script>

