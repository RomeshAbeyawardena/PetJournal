import petDetailsComponent from "./pet-details";
import addPetComponent from "./save-pet";
import loaderComponent from "./loader";
import datePickerComponent from "./date-picker";

const registerComponents = (vueInstance) => {
    loaderComponent.registerComponent(vueInstance);
    datePickerComponent.registerComponent(vueInstance);
    petDetailsComponent.registerComponent(vueInstance);
    addPetComponent.registerComponent(vueInstance);
}

export default registerComponents;