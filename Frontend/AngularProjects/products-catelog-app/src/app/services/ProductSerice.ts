import { inject, Injectable } from "@angular/core";
import { Product } from "../models/product";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";


@Injectable({
    providedIn:"root"
})

export class ProductService{

httpClient:HttpClient = inject(HttpClient);
apiUri:string = 'https://localhost:44389/api/Products';

getProductById(id:number) : Observable<Product>{
  return this.httpClient.get<Product>(this.apiUri + `/${id}`);
}

editProduct(id:number,product:Product){
  this.httpClient.put(this.apiUri + `/${id}`,product)
  alert('edited');
}


getProducts() : Observable<Product[]>{

  
  const token = localStorage.getItem('token') || '';
  const headers = new HttpHeaders({
    'Accept': 'application/json',
    'Authorization': `Bearer ${token}`
  });

  return this.httpClient.get<Product[]>(this.apiUri, { headers });
}
//    const products:Product[]=
//     [
//        {
//     productId: 1,
//     productName: "IPhone 12 (static data)",
//     price: 99000,
//     country: "China",
//     category: "Mobiles",
//     inStock: true
//   },
//   {
//     productId: 2,
//     productName: "Galaxy S26",
//     price: 99000,
//     country: "India",
//     category: "Mobiles",
//     inStock: true
//   },
//   {
//     productId: 3,
//     productName: "ThinkBook",
//     price: 75000,
//     country: "India",
//     category: "Laptops",
//     inStock: false
//   },
//   {
//     productId: 4,
//     productName: "Dell XPS 200",
//     price: 99950,
//     country: "India",
//     category: "Laptops",
//     inStock: true
//   },
//   {
//     productId: 5,
//     productName: "Galaxy Watch 7",
//     price: 75000,
//     country: "India",
//     category: "Smart Watches",
//     inStock: true
//   }
// ]
//     return products;
//}


}
