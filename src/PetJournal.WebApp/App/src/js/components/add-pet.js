import { VueComponentRegistration } from "./../utility";
import { mapActions, mapGetters } from 'vuex';

const petDetailsComponent = new VueComponentRegistration("add-pet", {
    template: require("./../../components/add-pet.html"),
    props: { id:Number },
    data() {
        return {
            newPet: {
                id: this.id,
                name: "",
                dateOfBirth: ""
            }
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