let data = 10;
let str = "Hello, World!";
let bool = true;
let arr = [1, 2, 3, 4, 5];
let obj = { name: "Alice", age: 30 };


console.log("Data:", data);
console.log("String:", str);
console.log("Boolean:", bool);
console.log("Array:", arr);
console.log("Object:", obj);

// Function declaration
function add(a, b) {
    return a + b;
}
console.log("Sum:", add(5, 3));

// Function expression
const sum = function (a, b) {
    return a + b;
}
console.log("Sum (function expression):", sum(10, 20));

// Arrow function
const arrowSum = (a, b) => a + b;
console.log("Sum (arrow function):", arrowSum(15, 25));

// Using for loop to iterate over the array
for(let i = 0; i < arr.length; i++) {
    console.log("Array element:", arr[i]);
}

// Using for...of loop to iterate over the array
for(let num of arr) {
    console.log("Array element (for...of):", num);
}

// Using if-else statement
if (data > 5) {
    console.log("Data is greater than 5");
} else {
    console.log("Data is not greater than 5");
}

// Using switch statement
switch (bool) {
    case true:
        console.log("Boolean is true");
        break;
    case false:
        console.log("Boolean is false");
        break;
    default:
        console.log("Boolean is neither true nor false");
}
// Using try-catch for error handling
try {
    let result = add(5, "3"); // This will cause an error
    console.log("Result:", result);
} catch (error) {
    console.error("An error occurred:", error.message);
}

// array methods
let newArr = arr.map(num => num * 2);
console.log("Mapped Array (doubled):", newArr);
let filteredArr = arr.filter(num => num > 3);
console.log("Filtered Array (greater than 3):", filteredArr);
let reducedValue = arr.reduce((acc, num) => acc + num, 0);
console.log("Reduced Value (sum of array):", reducedValue);

