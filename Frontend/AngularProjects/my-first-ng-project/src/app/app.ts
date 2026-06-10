import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  

title:string = "Welcome to my First Angular Application...!";


empName:string = "Ravi";
salary:number = 75000;
isActive:boolean=true;
pictureUrl:string = "https://placehold.net/avatar.svg";
  
}
