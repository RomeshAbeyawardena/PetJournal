import { DataType } from "./data-type";

export const PetType = function (id, name, description, created, modified) {
    DataType.call(this, id, created, modified)
    this.id = id;
    this.name = name;
    this.description = description;
}