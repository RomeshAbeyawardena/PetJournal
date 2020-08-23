import Promise from "promise";

var dataSet = [{
    id: 1,
    name: "Mia",
    dateOfBirth: new Date(2016, 9, 12),
    created: new Date(2020, 8, 21),
    modified: new Date(2020, 8, 21)
},{
    id: 2,
    name: "Totty",
    dateOfBirth: new Date(2018, 10, 16),
    created: new Date(2020, 8, 22),
    modified: new Date(2020, 8, 23)
}];

var dataSet2 = [{
    id: 1,
    name: "Cat",
    description: "",
    created: new Date(2020, 8, 21),
    modified: new Date(2020, 8, 21)
},{
    id: 2,
    name: "Dog",
    description: "",
    created: new Date(2020, 8, 22),
    modified: new Date(2020, 8, 23)
}];

const petService = {
    getPets() {
        return new Promise((resolve, reject) => {
            window.setTimeout(() => resolve(
                { 
                    data: dataSet, 
                    lastUpdated: Date() 
                }), 1000);
        });
    },
    getPetTypes() {
        return new Promise((resolve, reject) => {
            window.setTimeout(() => resolve({
                    data: dataSet2,
                    lastUpdated: Date()
                }), 550);
        });
    }
};

export default petService;