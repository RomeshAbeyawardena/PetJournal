export const DataType = function (id, created, modified) {
    this.id = Number(id);
    this.created = new Date(created);
    this.modified = new Date(modified);
}