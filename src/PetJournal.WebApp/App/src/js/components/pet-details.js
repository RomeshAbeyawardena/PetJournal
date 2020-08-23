import { VueComponentRegistration } from "./../utility";
import { mapActions, mapGetters } from 'vuex';

const petDetailsComponent = new VueComponentRegistration("pet-details", {
    template: require("./../../components/pet-details.html"),
    props: { petId:Number },
    data() {
        return {
            id: this.petId
        }
    },
    computed: {
        selectedPet() {
            return this.pet(this.id);
        },
        ...mapGetters(['pets','pet', 'isPetsLoaded'])
    },
    methods: {
        ...mapActions(['savePet']),
        viewPet(id) {
            this.id = id;
        }
    }
});

export default petDetailsComponent;