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
            var foundPet = findPet(state, pet.id);
            if (foundPet) {
                utility.updateChanges(pet, foundPet);
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
                    context.commit('loadPets', pets);
                    context.commit('setIsPetsLoaded', pets.length > 0)
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