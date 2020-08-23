export const Pet = function (id, name, dateOfBirth) {
    this.id = id;
    this.name = name;
    this.dateOfBirth = new Date(dateOfBirth);
}