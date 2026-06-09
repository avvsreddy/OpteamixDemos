console.log('Start of the program');

setTimeout(() => {
    console.log('This is an asynchronous operation');
}, 2000);
console.log('Doing some other work while waiting for the asynchronous operation to complete');

console.log('End of the program');
