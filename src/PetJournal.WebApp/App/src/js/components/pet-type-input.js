import uniqueIdentifierGeneratorService from "./../services/unique-identifier-generator-service";
import { VueComponentRegistration } from "./../utility";
import { mapActions, mapGetters } from 'vuex';
import { utility } from "./../utility";
const autocomplete = require("autocomplete.js");

const petTypeInput = new VueComponentRegistration("pet-type-input", {
    template: require("./../../components/pet-type-input.html"),
    props: {
        value: String
    },
    computed: {
        ...mapGetters(['isPetTypesLoaded', 'petTypes'])
    },
    watch: {

    },
    data() {
        return {
            selectedItem: null,
            val: this.value,
            autoCompleteInstance: null,
            uniqueComponentId: uniqueIdentifierGeneratorService.generate()
        }
    },
    methods: {
        searchPetTypes: function (query, cb) {
            var items = utility.find(this.petTypes, "name", query);
            cb(items);
        },
        OnItemSelected(newValue) {
            console.log(newValue);
        },
        ...mapActions([])
    },
    mounted() {
        var parentContext = this;

        this.autoCompleteInstance = autocomplete("#" + this.$refs.typeAheadInput.id, { hint: true }, [{
            source: parentContext.searchPetTypes,
            displayKey: "name"
        }]).on('autocomplete:selected', function (event, suggestion, dataset, context) {
            parentContext.selectedItem = suggestion;
            parentContext.$emit("input", suggestion);
        });;

    }
});

export default petTypeInput;