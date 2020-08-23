import { DataType } from "./data-type";

export const Pet = function (id, name, dateOfBirth, created, modified) {
    DataType.call(this, id, name, created, modified)
    
    this.name = name;
    this.dateOfBirth = new Date(dateOfBirth);
}