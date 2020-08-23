import petService from "../services/pet-service";
import { Pet } from "../model/pet";

const findPet = (state, id) => state.pets.find(pet => pet.id === id);

const petDetails = {
    state: {
        pets: [],
        isLoaded: false
    },
    mutations: {
        setIsPetsLoaded(state, value) {
            state.isLoaded = value;
        },
        addPet(state, pet) {
            state.pets.push(pet);
        },
        updatePet(state, pet) {
            var foundPet = findPet(state, pet.Id);
            if (foundPet) {
                foundPet = pet;
            }
        },
        loadPets(state, pets) {
            state.pets = pets;
        }
    },
    getters: {
        pets(state) {
            return state.pets;
        },
        pet:(state) => (id) => {
            return findPet(state, id);
        },
        isPetsLoaded(state) {
            return state.isLoaded;
        }
    },
    actions: {
        loadPets(context) {
            return petService
                .getPets()
                .then((pets) => { 
                    context.commit('loadPets', pets);
                    context.commit('setIsPetsLoaded', pets.length > 0)
                });
        },
        savePet({commit, state}, pet) {

            var petModel = new Pet(pet.id, pet.name, pet.dateOfBirth);
            if (findPet(state, pet.id)) {
                commit('updatePet', petModel);
            }
            else {
                commit('addPet', petModel);
            }
        }
    }
}

export default petDetails;