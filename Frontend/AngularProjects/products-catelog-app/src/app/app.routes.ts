import { Routes } from '@angular/router';
import { Home } from './home/home';
import { Aboutus } from './aboutus/aboutus';
import { Contact } from './contact/contact';
import { ProductList } from './product-list/product-list';
import { NotFound } from './not-found/not-found';
import { ProductCreate } from './product-create/product-create';
import { ProductCreateReactive } from './product-create-reactive/product-create-reactive';
import { ProductEdit } from './product-edit/product-edit';

export const routes: Routes = 
[


// http://opteamix.com/about
{
    path:'',
    component:Home,
    title:'Home'
},
{
    path:'home',
    component:Home,
    title:'Home'
},
{
    path:'about',
    component:Aboutus,
    title:'About Us'
},
{
    path:'contact-us',
    component:Contact,
    title:'Contact Us'
},
{
    path:'manage-products',
    component:ProductList,
    title:'Manage Products'
    
    
},

{
    path:'product-edit/:id',
    component:ProductEdit
},
{
    path:'product-create',
    component:ProductCreateReactive,
    title:'Create Product'
},
{
    path:'**',
    component:NotFound
}


];
