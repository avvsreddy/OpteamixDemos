import { Component } from '@angular/core';
import { Product } from '../models/product';
import { FormsModule, NgForm } from '@angular/forms';
import { JsonPipe } from '@angular/common';

@Component({
  selector: 'app-product-create',
  imports: [FormsModule,JsonPipe],
  templateUrl: './product-create.html',
  styleUrl: './product-create.css',
})
export class ProductCreate {

onSubmit() {

//console.log(formData)
// send the form data to the api for saving



}

productInput:Product=
{
  productId:0,
  productName:'',
  price:0,
  category:'',
  country:'',
  inStock:false
};

}
