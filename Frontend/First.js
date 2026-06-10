"use strict";
// declare some variables
exports.__esModule = true;
exports.Employee = void 0;
var pName = "Ramesh";
var age = 24;
var isActive = true;
console.log("The name is ".concat(pName, " and age is ").concat(age));
function Sum(fno, sno) {
    return fno + sno;
}
var s = Sum(10, 20);
console.log(s);
var Employee = /** @class */ (function () {
    function Employee(empid, ename) {
        this.empid = empid;
        this.ename = ename;
    }
    Employee.prototype.display = function () {
        console.log("".concat(this.ename, " has an empid ").concat(this.empid));
    };
    return Employee;
}());
exports.Employee = Employee;
