import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { IProduct } from '../interfaces/IProduct';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  
products:IProduct[] = [
  {
  id:101,
  name:"I Phone",
  price:99999,
  isAvailable:true
  },
   {
  id:102,
  name:"I Phone X",
  price:99999,
  isAvailable:false,
    //brand:'apple'

  },
   {
  id:101,
  name:"Galaxy S26",
  price:99999,
  isAvailable:true
  },
   {
  id:101,
  name:"Oppo M45",
  price:99999,
  isAvailable:false
  },
   {
  id:101,
  name:"I Watch",
  price:99999,
  isAvailable:true
  }
  
]

}
