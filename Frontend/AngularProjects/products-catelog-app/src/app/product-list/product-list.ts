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

  products$!:Observable<Product[]>;

  errMsg:string='';

  ngOnInit(): void {
    // fetch from api and handle if any errors
    this.products$ = this.pService.getProducts()
      .pipe(
        catchError(err => {
          this.errMsg = err?.message || 'Failed to load products.';
          return of([] as Product[]);
        })
      );

  }
  


}
