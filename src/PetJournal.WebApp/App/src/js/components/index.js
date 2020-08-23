import petDetailsComponent from "./pet-details";
import addPetComponent from "./add-pet";

const registerComponents = (vueInstance) => {
    petDetailsComponent.registerComponent(vueInstance);
    addPetComponent.registerComponent(vueInstance);
}

export default registerComponents;