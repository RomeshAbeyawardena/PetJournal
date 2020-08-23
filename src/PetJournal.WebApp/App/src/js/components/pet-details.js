import { VueComponentRegistration } from "./../utility";
import { mapActions, mapGetters } from 'vuex';

const petDetailsComponent = new VueComponentRegistration("pet-details", {
    template: require("./../../components/pet-details.html"),
    props: { id:Number },
    watch: {
        id(newValue) {
            this.petId = newValue;
            this.selectedPet = this.pet(newValue);
        }
    },
    data() {
        return {
            petId: this.id,
            selectedPet: null
        }
    },
    computed: {
        ...mapGetters(['pets','pet', 'isPetsLoaded'])
    },
    methods: {
        ...mapActions(['savePet'])
    }
});

export default petDetailsComponent;