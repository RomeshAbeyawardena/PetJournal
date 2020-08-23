import petService from "../services/pet-service";
import { Pet } from "../model/pet";
import { utility } from "../utility";
import Promise from "promise";

const findPet = (state, id) => {
    return state.pets.find(pet => pet.id === id);
}

const petDetails = {
    state: {
        pets: [],
        lastUpdated: null,
        isLoaded: false
    },
    mutations: {
        setIsPetsLoaded(state, value) {
            state.isLoaded = value;
        },
        setLastUpdated(state, value) {
            state.lastUpdated = value;
        },
        addPet(state, pet) {
            state.pets.push(pet);
        },
        updatePet(state, pet) {
            var foundPet = findPet(state, pet.id);
            if (foundPet) {
                utility.updateChanges(pet, foundPet);
            }
        },
        loadPets(state, pets) {
            state.pets = pets;
        },
    },
    getters: {
        pets(state) {
            return state.pets;
        },
        pet:(state) => (id) => {
            var pet = findPet(state, id);
            return pet;
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
                    context.commit('loadPets', pets.data);
                    context.commit('setIsPetsLoaded', pets.data.length > 0)
                    context.commit("setLastUpdated", pets.lastUpdated)
                });
        },
        savePet({commit, state}, pet) {
            
            var petModel = new Pet(pet.id, pet.name, pet.dateOfBirth);

            var foundPet = findPet(state, petModel.id);

            if (foundPet) {
                commit('updatePet', petModel);
            }
            else {
                commit('addPet', petModel);
            }
        }
    }
}

export default petDetails;