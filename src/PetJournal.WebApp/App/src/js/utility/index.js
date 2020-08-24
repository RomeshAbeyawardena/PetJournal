import Vuex from "vuex";

export const VueComponentRegistration = function (componentName, componentConfig) {
    this.registerComponent = function (vueInstance) {
        vueInstance.component(componentName, componentConfig);
    }
}

export const VuexRegistration = (vueInstance, modules) => {
    vueInstance.use(Vuex);

    return new Vuex.Store({
        modules: modules
    });
}

export const utility = {
    updateChanges(source, destination) {
        for (var property in source) {
            if (destination[property] !== source[property]) {
                destination[property] = source[property];
            }
        }
    },
    find(items, field, text) {
        text = text.toLowerCase().split(' ');
        return items.filter(function (item) {
            return text.every(function (el) {
                return item[field].toLowerCase().indexOf(el) > -1;
            });
        });
    }
}