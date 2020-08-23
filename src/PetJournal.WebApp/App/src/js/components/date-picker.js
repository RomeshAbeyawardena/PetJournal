import { VueComponentRegistration } from "./../utility";

const loaderComponent = new VueComponentRegistration("date-picker", {
    template: require("./../../components/date-picker.html"),
    props: {
        value: Date
    },
    computed: {
        getDate() {
            return new Date(
                this.date.year,
                this.date.month - 1,
                this.date.day);
        }
    },
    data() {
        return {
            date: {
                day: this.value?.getDate(),
                month: this.value?.getMonth() + 1,
                year: this.value?.getYear()
            }
        }
    },
    methods: {
        processKey(e) {
            var target = e.target;
            var isCtrlKey = e.keyCode === 8
                || e.keyCode === 9;
            var isNumericInput = !isNaN(e.key);
            if (isNumericInput
                || isCtrlKey) {
                if (!isCtrlKey
                    && target.value.length >= target.maxLength) {
                    e.preventDefault();
                }

                return;
            }
            else {
                e.preventDefault();
            }
        },
        onChange(e) {
            this.$emit("input", this.getDate);
        }
    }
});

export default loaderComponent;