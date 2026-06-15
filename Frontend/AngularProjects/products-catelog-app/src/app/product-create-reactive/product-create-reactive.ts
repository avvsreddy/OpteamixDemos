import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-product-create-reactive',
  imports: [ReactiveFormsModule],
  templateUrl: './product-create-reactive.html',
  styleUrl: './product-create-reactive.css',
})
export class ProductCreateReactive {
onSubmit() {

if(this.productForm.valid){
  // post the form data to api
  console.log(this.productForm.value)
}
else{
  console.log('Invalid form data');
}
}

fb:FormBuilder = inject(FormBuilder);
productForm:FormGroup;
constructor(){

  this.productForm = this.fb.group({
    'productName':['',Validators.required],
    'price':[1,[Validators.min(1),Validators.max(999999),Validators.required]],
    'category':['',Validators.required],
    'country':['',Validators.required],
    'inStock':[false]
  })


}


}
