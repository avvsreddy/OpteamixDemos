import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Header } from './header/header';
import { Footer } from './footer/footer';
import { NavBar } from "./nav-bar/nav-bar";
import { Contact } from "./contact/contact";
import { Aboutus } from "./aboutus/aboutus";
import { Home } from "./home/home";
import { NotFound } from './not-found/not-found';
import { ProductCreate } from './product-create/product-create';
import { ProductCreateReactive } from './product-create-reactive/product-create-reactive';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Header, Footer, NavBar, Contact, Aboutus, Home, NotFound,ProductCreateReactive],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('products-catelog-app');
}
