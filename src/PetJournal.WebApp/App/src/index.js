import Vue from "vue";
import app from "./js/app";
import registerComponents from "./js/components";
import registerStoreModules from "./js/modules";

registerComponents(Vue);
var store = registerStoreModules(Vue);

app.ready(() => {
    new Vue(app.getConfig(store))
});