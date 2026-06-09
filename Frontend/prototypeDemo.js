// Prototype demonstration in JavaScript

// Define a constructor function for a Person
function Person(name, age) {
    this.name = name;
    this.age = age;
}
// Add a method to the Person prototype
Person.prototype.greet = function() {
    console.log(`Hello, my name is ${this.name} and I am ${this.age} years old.`);
};

// Create an instance of Person
const person1 = new Person('Alice', 30);
const person2 = new Person('Bob', 25);

// Call the greet method on each instance
person1.greet(); // Output: Hello, my name is Alice and I am 30 years old.
person2.greet(); // Output: Hello, my name is Bob and I am 25 years old.

// Add another method to the Person prototype
Person.prototype.isAdult = function() {
    return this.age >= 18;
};
// Check if the persons are adults
console.log(`${person1.name} is an adult: ${person1.isAdult()}`); // Output: Alice is an adult: true
console.log(`${person2.name} is an adult: ${person2.isAdult()}`); // Output: Bob is an adult: true

// In this example, we have defined a Person constructor function and added methods to its prototype. This allows all instances of Person to share the same methods, demonstrating the use of prototypes in JavaScript.

// using __proto_ to access the prototype of an object
console.log(person1.__proto__ === Person.prototype); // Output: true
console.log(person2.__proto__ === Person.prototype); // Output: true
// difference between __proto__ and prototype
// __proto__ is an internal property of an object that points to the prototype of the constructor function that created it. It is used to access the prototype chain of an object.
// prototype is a property of a constructor function that is used to define methods and properties that will be shared by all instances created by that constructor. It is the actual object that instances will inherit from.  

// class syntax in JavaScript (ES6)
class Animal {
    constructor(name, species) {
        this.name = name;
        this.species = species;
    }
}
Animal.prototype.describe = function() {
    console.log(`${this.name} is a ${this.species}.`);
}

class Dog extends Animal {
    constructor(name, breed) {
        super(name, 'Dog');
        this.breed = breed;
    }
    describe() {
        console.log(`${this.name} is a ${this.breed} breed of dog.`);
    }
}