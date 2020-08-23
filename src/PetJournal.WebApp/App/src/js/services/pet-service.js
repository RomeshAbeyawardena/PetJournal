import Promise from "promise";

var dataSet = [{
    id: 1,
    name: "Mia",
    dateOfBirth: new Date(2016, 9, 12)
},{
    id: 2,
    name: "Totty",
    dateOfBirth: new Date(2018, 10, 16)
}];

const petService = {
    getPets() {
        return new Promise((resolve, reject) => {
            resolve(dataSet);
        });
    }
};

export default petService;