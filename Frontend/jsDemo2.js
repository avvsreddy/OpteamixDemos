//var x = 0;
function Increment() {
    var x = 0;
    // Closure: A closure is a function that has access to its own scope, the outer function's scope, and the global scope. In this case, the inner function (the one returned by Increment) has access to the variable x defined in the outer function (Increment). This allows the inner function to modify and access x even after Increment has finished executing.
    return function() {
        x++;
        console.log(x);
    }
}

var inc = Increment();

inc();
inc();
inc();

