import { Component, ChangeDetectorRef, inject, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { filter, Subject, takeUntil } from 'rxjs';
import { Product } from '../models/product';
import { ProductService } from '../services/ProductSerice';
import { JsonPipe, NgFor } from '@angular/common';


@Component({
  selector: 'app-aboutus',
  imports:[JsonPipe,NgFor],
  templateUrl: './aboutus.html',
  styleUrls: ['./aboutus.css'],
})
export class Aboutus implements OnInit{
  data1: string = '';
  data2: number = 0;
  data3: boolean = false;
  products: Product[] = [];

  private readonly ps = inject(ProductService);
  private readonly router = inject(Router);
  private readonly cdr = inject(ChangeDetectorRef);


  ngOnInit(): void {
    this.loadProducts();
  
  }

 

  private loadProducts(): void {
    this.data1 = 'initialized in ngoninit';
    this.data2 = 1234;
    this.data3 = true;
    this.ps.getProducts().subscribe({
      next: data => {
        this.products = data;
        //this.cdr.markForCheck();
        this.cdr.detectChanges();

      },
      error: err => {
        console.error('Failed to load products', err);
      }
    });
  }
}
