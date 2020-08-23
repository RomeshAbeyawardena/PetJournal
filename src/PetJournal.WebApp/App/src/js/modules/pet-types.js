import petService from "../services/pet-service";
import { PetType } from "../model/pet-type";
import { utility } from "../utility";
import Promise from "promise";

const findPetType = (state, id) => {
    return state.petTypes.find(petType => petType.id === id);
}

const petDetails = {
    state: {
        petTypes: [],
        lastUpdated: null,
        isLoaded: false
    },
    mutations: {
        loadPetTypes(state, petTypes) {
            state.petTypes = petTypes;
        },
        setIsPetTypesLoaded(state, value) {
            state.isLoaded = value;
        },
        setPetTypesLastUpdated(state, value) {
            state.lastUpdated = value;
        },
        addPet(state, pet) {
            state.petTypes.push(pet);
        },
        updatePetType(state, petType) {
            var foundPetType = findPet(state, pet.id);
            if (foundPetType) {
                utility.updateChanges(petType, foundPetType);
            }
        }
    },
    getters: {
        petTypes(state) {
            return state.petsTypes;
        },
        petType:(state) => (id) => {
            var pet = findPet(state, id);
            return pet;
        },
        isPetTypesLoaded(state) {
            return state.isLoaded;
        }
    },
    actions: {
        loadPetTypes(context) {
            return petService
                .getPetTypes()
                .then((payload) => { 
                    context.commit('loadPetTypes', payload.data);
                    context.commit('setIsPetTypesLoaded', payload.data.length > 0)
                    context.commit("setPetTypesLastUpdated", payload.lastUpdated)
                });
        },
        savePetType({commit, state}, petType) {
            
            var petTypeModel = new PetType(petType.id, petType.name, petType.description);

            var foundPetType = findPetType(state, petTypeModel.id);

            if (foundPetType) {
                commit('updatePetType', petTypeModel);
            }
            else {
                commit('addPet', petModel);
            }
        }
    }
}

export default petDetails;