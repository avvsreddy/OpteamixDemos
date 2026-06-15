import { Routes } from '@angular/router';
import { Home } from './home/home';
import { Aboutus } from './aboutus/aboutus';
import { Contact } from './contact/contact';
import { ProductList } from './product-list/product-list';
import { NotFound } from './not-found/not-found';

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
    path:'**',
    component:NotFound
}


];
