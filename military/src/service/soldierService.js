import { ref } from "vue";
import axios from "axios";

const soldierService = (function(){
    const soldier = ref([
        {
            id:9999, 
            soldierImage: "",
            firstName: "Bob",
            lastName: "Builder",
            age: 25,
            gender: "Male",
            rank: "colonel",
            specialSoldier: true,
            soldierType: "pilot"
        },
        {
            id:9998, 
            soldierImage: "",
            firstName: "Sigrid",
            lastName: "Builder",
            age: 24,
            gender: "Female",
            rank: "colonel",
            specialSoldier: false,
            soldierType: "pilot"
        }
    ]);

    //henting av soldater
    const soldierControllerUrl = "https://localhost:7262/api/Soldier";

    //denne sier hvor bilde skal legges til og her bruker jeg funkjonen PostSoldier i ImageUpload som 
    //skal sende bilde til riktig mappe
    const soldierImageUploadControllerUrl = "https://localhost:7262/ImageUpload/PostSoldierImage";


    // denne henter alle soldiers og legger dem i arrayet
   (async () => {
       const Request = await axios.get(soldierControllerUrl);
       soldier.value = Request.data;
   })();

    //henter alle soldater fra arrayet
    const getAllSoldiers = () => {
        return soldier;
    }

    //denne henter all info om soldaten etter iden som ble sendt inn
    const getById = async ( id ) => {
        const Request = await axios.get(`https://localhost:7262/api/Soldier/${id}`);
        return Request.data;
    }
 
    //PutSoldier sin jobb er å endre på soldaten sin data og passer på at riktig soldat blir endret på ved bruk av id
    //den finner riktig id ved å sammenligne arrayet sitt id med det brukeren skrev.
    const PutSoldier = async ( editedSoldier ) => {
        await axios.put( soldierControllerUrl , editedSoldier )

        const temporarySoldierArray = JSON.parse( JSON.stringify( soldier.value ));
        const index = temporarySoldierArray.findIndex( soldier => parseInt( soldier.id ) === parseInt( editedSoldier.id ));

        soldier.value[index].soldierImage = editedSoldier.soldierImage
        soldier.value[index].firstName = editedSoldier.firstName 
        soldier.value[index].lastName = editedSoldier.lastName
        soldier.value[index].age = editedSoldier.age
        soldier.value[index].gender = editedSoldier.gender
        soldier.value[index].rank = editedSoldier.rank
        soldier.value[index].specialSoldier = editedSoldier.specialSoldier
        soldier.value[index].soldierType = editedSoldier.soldierType


    }
    //her kan man legge til soldat med bilde
    const postSoldier = ( newSoldier , image ) => {
        //denne har rollen å legge til soldater etter infomasjon som har blitt opplyst
        axios.post( soldierControllerUrl , newSoldier );

        //denne legger til bilde
        axios({
            method: "POST",
            url: soldierImageUploadControllerUrl,
            data: image,
            config: { header: { "Content-Type": "multipart/form-data"}}
        });
    }
    //deleteSoldier funker på samme måtte som getById, men her slettes soldaten etter id
    const deleteSoldier = async ( soldierToDeleteId ) => {
        await axios.delete(`https://localhost:7262/api/Soldier/${soldierToDeleteId}`)
    }


    return{
        getAllSoldiers,
        getById,
        PutSoldier,
        postSoldier,
        deleteSoldier,
        
        
    }
}());

export default soldierService;