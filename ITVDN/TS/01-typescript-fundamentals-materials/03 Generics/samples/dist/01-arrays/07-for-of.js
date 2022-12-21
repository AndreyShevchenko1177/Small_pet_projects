class User {
    constructor(name, age) {
        this.name = name;
        this.age = age;
    }
}
let users = [];
users[0] = new User("Jim", 20);
users[1] = new User("Ivan", 25);
users[2] = new User("Bob", 23);
users[3] = new User("David", 30);
console.log("for ... in"); // обход по свойствам объекта (в данном случае индексы массива)
for (let index in users) {
    console.log(index);
}
console.log("for ... of"); // обход значений массива
for (let value of users) {
    console.log(value);
}
//# sourceMappingURL=07-for-of.js.map