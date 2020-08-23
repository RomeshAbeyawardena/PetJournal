import { VuexRegistration } from "./../utility";
import petDetailsStoreModule from "./../modules/pet-details";

const moduleRegistration = (vueInstance) => new VuexRegistration(vueInstance, { petDetails: petDetailsStoreModule });

export default moduleRegistration;