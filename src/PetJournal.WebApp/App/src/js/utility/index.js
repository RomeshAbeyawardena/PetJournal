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

export const utility = {
    updateChanges(source, destination) {
        for (var property in source) {
            destination[property] = source[property];
        }
    },
    wait(ms) {
        var d = new Date();
        var d2 = null;
        do { d2 = new Date(); }
        while(d2-d < ms);
    }

}