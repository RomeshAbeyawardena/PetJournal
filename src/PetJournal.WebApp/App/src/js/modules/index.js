import { VuexRegistration } from "./../utility";
import petDetailsStoreModule from "./../modules/pet-details";
import petTypesStoreModule from "./../modules/pet-types";

const moduleRegistration = (vueInstance) => new VuexRegistration(vueInstance, { 
    petTypes: petTypesStoreModule, 
    petDetails: petDetailsStoreModule 
});

export default moduleRegistration;