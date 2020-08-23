import { VueComponentRegistration } from "./../utility";

const loaderComponent = new VueComponentRegistration("loader", {
    template: require("./../../components/loader.html")
});

export default loaderComponent;