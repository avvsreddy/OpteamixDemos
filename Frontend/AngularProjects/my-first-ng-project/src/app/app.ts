import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  

title:string = "Welcome to my First Angular Application...!";


empName:string = "Ravi";
salary:number = 75000;
isActive:boolean=true;
pictureUrl:string = "https://placehold.net/avatar.svg";
  
display()
{
  alert('hello');
}


}
