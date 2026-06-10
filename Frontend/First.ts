// declare some variables

let pName:string = "Ramesh";
let age:number = 24;
let isActive:boolean = true;

console.log(`The name is ${pName} and age is ${age}`)

function Sum(fno:number, sno:number):number{
    return fno + sno;
}

let s = Sum(10,20);
console.log(s);


export class Employee
{
    empid:number ;
    ename:string;

    constructor(empid:number,  ename:string){
        this.empid = empid;
        this.ename = ename;
    }

    display():void{
        console.log(`${this.ename} has an empid ${this.empid}`);
    }
}




