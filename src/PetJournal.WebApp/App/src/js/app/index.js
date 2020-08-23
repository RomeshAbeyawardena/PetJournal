import { mapActions } from 'vuex';

const app = {
    ready(callback) {
        if (document.readyState !== 'loading') {
            // Document is already ready, call the callback directly
            callback();
        } else if (document.addEventListener) {
            // All modern browsers to register DOMContentLoaded
            document.addEventListener('DOMContentLoaded', callback);
        } else {
            // Old IE browsers
            document.attachEvent('onreadystatechange', () => {
                if (document.readyState === 'complete') {
                    callback();
                }
            });
        }
    },
    getConfig(store) {
        return {
            el: '#app',
            store: store,
            data: {
                hasPetsLoaded: false,
                hasPetTypesLoaded: false,
                hasChanges: false
            },
            methods: {
                ...mapActions(['loadPets', 'loadPetTypes'])
            },
            watch: {
                hasChanges: function () {
                    window.onbeforeunload = function (e) {
                        return confirm("You have unsaved changes, are you sure?");
                    };
                }
            },
            created() {
                var context = this;
                this.loadPets().then(() => context.hasPetsLoaded = true);
                this.loadPetTypes().then(() => context.hasPetTypesLoaded = true);
            }
        }
    }
}

export default app;