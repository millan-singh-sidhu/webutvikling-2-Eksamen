import axios from "axios";
import { ref } from "vue";

const weaponService = (function(){

    const weapon = ref([
        {
            id:8989,
            weaponImage:"",
            weaponName:"M1 Garand",
            weaponType:"Rifle",
            ammoCapacity: 20,
            ammoType:"Normale kuler",
            automatic: true,
            semiAutomatic:true,
            singelFire: false
        }
    ]);

    //henter alle våpen
    const weaponControllerUrl = "https://localhost:7262/api/weapon";
    
    //denne sier hvor bilde skal legges til og blir bruket av postWeapon for at bilde skal bli lagret
    //på riktig sted
    const weaponImageUploadControllerUrl = "https://localhost:7262/ImageUpload/PostWeaponImage";

    //henter alle våpen og legger dem til i arrayet
    (async () => {
        const Request = await axios.get( weaponControllerUrl );
        weapon.value = Request.data;
    })();

    //henter alle våpen fra arrayet
    const getAllWeapons = () => {
        return weapon;
    }

    //denne henter all info om våpen
    const getById = async ( id ) => {
        const Request = await axios.get(`https://localhost:7262/api/Weapon/${id}`);
        return Request.data;
    }

    //putWeapon sin jobb er å endre dataen til et våpen og passer på at riktig blir endret ved bruk av id
    //den finner riktig våpen ved bruk av id og sammenligner arrayet sitt id med det hva brukeren skrev
    const putWeapon = async ( editedWeapon ) => {

        await axios.put( weaponControllerUrl, editedWeapon )

        const temporaryWeaponArray = JSON.parse( JSON.stringify( weapon.value ));
        const index = temporaryWeaponArray.findIndex( weapon => parseInt( weapon.id ) === parseInt( editedWeapon.id ));

        weapon.value[index].weaponImage = editedWeapon.weaponImage
        weapon.value[index].weaponName = editedWeapon.weaponName
        weapon.value[index].weaponType = editedWeapon.weaponType
        weapon.value[index].ammoCapacity = editedWeapon.ammoCapacity
        weapon.value[index].ammoType = editedWeapon.ammoType
        weapon.value[index].automatic = editedWeapon.automatic
        weapon.value[index].semiAutomatic = editedWeapon.semiAutomatic
        weapon.value[index].singelFire = editedWeapon.singelFire
    }

    //her kan man legge til våpen med bilde
    const postWeapon = ( newWeapon , image ) => {
        //denne har rollen å legge til våpen etter infomasjon som har blitt opplyst
        axios.post( weaponControllerUrl, newWeapon );
        
        //denne legger til bilde
        axios({
            method: "POST",
            url: weaponImageUploadControllerUrl,
            data: image,
            config: { header: { "Content-Type": "multipart/form-data"}}
        })
    }

    //deleteWeapon funker på samme måtte som getById, men her slettes våpen etter id
    const deleteWeapon = async ( weaponToDeleteId ) => {
        await axios.delete(`https://localhost:7262/api/weapon/${weaponToDeleteId}`)
    }


    return {
        getAllWeapons,
        getById,
        putWeapon,
        postWeapon,
        deleteWeapon,
        
    }
}());

export default weaponService;