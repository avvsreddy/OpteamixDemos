import { Component, inject, OnInit } from '@angular/core';
import { ProductService } from '../services/ProductSerice';
import { Product } from '../models/product';
import { CommonModule, CurrencyPipe, UpperCasePipe } from '@angular/common';
import { NavigationEnd, Router, RouterLink } from "@angular/router";
import { filter, Observable, catchError, of } from 'rxjs';

@Component({
  //standalone: true,
  selector: 'app-product-list',
  imports: [CommonModule, CurrencyPipe, UpperCasePipe, RouterLink],
  templateUrl: './product-list.html',
  styleUrl: './product-list.css',
})
export class ProductList implements OnInit
{ 
    
private pService : ProductService = inject(ProductService);

  products!:Observable<Product[]>;
  
  errMsg:string='';
  router:Router=inject(Router);
  
  ngOnInit(): void {
   
    // call service method to get the products and catch any API errors
    this.products = this.pService.getProductsFromApi().pipe(
      catchError((error) => {
        // const errDetail =
        //   (error as any)?.message ||
        //   (error as any)?.statusText ||
        //   (error as any)?.error?.message ||
        //   JSON.stringify(error);
        this.errMsg = 'Failed to load products. Please try again later. ' + error.message;
        return of([] as Product[]);
      })
    );
  }
  


}
