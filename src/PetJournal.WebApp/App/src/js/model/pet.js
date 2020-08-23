export const Pet = function (id, name, dateOfBirth) {
    this.id = Number(id);
    this.name = name;
    this.dateOfBirth = new Date(dateOfBirth);
}