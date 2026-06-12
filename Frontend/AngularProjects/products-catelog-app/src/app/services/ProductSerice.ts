import { Injectable } from "@angular/core";
import { Product } from "../models/product";


@Injectable({
    providedIn:"root"
})

export class ProductService{

getProducts() : Product[]{

   const products:Product[]=
    [
       {
    productId: 1,
    productName: "IPhone 12",
    price: 99000,
    country: "China",
    category: "Mobiles",
    inStock: true
  },
  {
    productId: 2,
    productName: "Galaxy S26",
    price: 99000,
    country: "India",
    category: "Mobiles",
    inStock: true
  },
  {
    productId: 3,
    productName: "ThinkBook",
    price: 75000,
    country: "India",
    category: "Laptops",
    inStock: false
  },
  {
    productId: 4,
    productName: "Dell XPS 200",
    price: 99950,
    country: "India",
    category: "Laptops",
    inStock: true
  },
  {
    productId: 5,
    productName: "Galaxy Watch 7",
    price: 75000,
    country: "India",
    category: "Smart Watches",
    inStock: true
  }
]
    return products;
}


}
