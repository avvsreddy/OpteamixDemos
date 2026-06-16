import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../models/product';
import { ProductService } from '../services/ProductSerice';
import { FormsModule } from '@angular/forms';
import { Observable } from 'rxjs';
import { AsyncPipe, NgIf } from '@angular/common';

@Component({
  selector: 'app-product-edit',
  imports: [FormsModule, AsyncPipe],
  templateUrl: './product-edit.html',
  styleUrl: './product-edit.css',
})
export class ProductEdit implements OnInit {

onSubmit() {
  this.product.subscribe( p => {
    this.pService.editProduct(parseInt(this.productId), p);
  });
}

productId:string='';
//product!:Product;
product!:Observable<Product>;
pService:ProductService = inject(ProductService);
route:ActivatedRoute = inject(ActivatedRoute);



ngOnInit(): void {
  this.route.paramMap.subscribe(params => {
    this.productId = params.get('id') || '';
    this.product = this.pService.getProductById(parseInt(this.productId))
    })
  };

  //alert('product id ' + this.productId);
}


