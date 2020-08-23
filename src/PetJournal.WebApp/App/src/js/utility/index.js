import Vuex from "vuex";

export const VueComponentRegistration = function(componentName, componentConfig) {
    this.registerComponent = function(vueInstance) {
        vueInstance.component(componentName, componentConfig);
    }
}

export const VuexRegistration = (vueInstance, modules) => {
    vueInstance.use(Vuex);

    return new Vuex.Store({
        modules: modules
    });
}