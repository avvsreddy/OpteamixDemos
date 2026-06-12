import { Component, inject, OnInit } from '@angular/core';
import { ProductService } from '../services/ProductSerice';
import { Product } from '../models/product';
import { CurrencyPipe, UpperCasePipe } from '@angular/common';
import { RouterLink } from "@angular/router";

@Component({
  selector: 'app-product-list',
  imports: [CurrencyPipe, UpperCasePipe, RouterLink],
  templateUrl: './product-list.html',
  styleUrl: './product-list.css',
})
export class ProductList implements OnInit
{ 
    
private pService : ProductService = inject(ProductService);
//constructor(private pService:ProductService){
//  this.pService = pService;
//}




  products:Product[] = [];
  ngOnInit(): void {
    // call service method to get the products
    let pService:ProductService = new ProductService();
    this.products = pService.getProducts();
  }
 
  
  


}
