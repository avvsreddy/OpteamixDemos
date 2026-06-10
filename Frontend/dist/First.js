"use strict";
// declare some variables
Object.defineProperty(exports, "__esModule", { value: true });
exports.Employee = void 0;
let pName = "Ramesh";
let age = 24;
let isActive = true;
console.log(`The name is ${pName} and age is ${age}`);
function Sum(fno, sno) {
    return fno + sno;
}
let s = Sum(10, 20);
console.log(s);
class Employee {
    constructor(empid, ename) {
        this.empid = empid;
        this.ename = ename;
    }
    display() {
        console.log(`${this.ename} has an empid ${this.empid}`);
    }
}
exports.Employee = Employee;
