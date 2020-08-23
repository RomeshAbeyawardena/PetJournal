import { VueComponentRegistration } from "./../utility";
import { mapActions, mapGetters } from 'vuex';

const petDetailsComponent = new VueComponentRegistration("add-pet", {
    template: require("./../../components/save-pet.html"),
    props: { petId:Number },
    data() {
        var values = {
            newPet: {
                id: this.petId,
                name: "",
                dateOfBirth: new Date()
            }
        };

        return values;
    },
    computed: {
        ...mapGetters(['pets','pet', 'isPetsLoaded'])
    },
    methods: {
        ...mapActions(['savePet'])
    }
});

export default petDetailsComponent;