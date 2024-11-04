import { Component, Inject, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./layout/header/header.component";
import { HttpClient } from '@angular/common/http';
import { Pagination } from './shared/models/Pagination';
import { Product } from './shared/models/Product';
import { ShopService } from './core/service/shop.service';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  private shopService = inject(ShopService)
  title = 'Skinet';
  products: Product[] = [];

  ngOnInit(): void {
    this.shopService.getProduct().subscribe({
      next: response => this.products = response.data,
      error: error => console.log(error),
      complete: () => console.log('complete')
   })
  }

  // constructor(private http: HttpClient){
  // }
}
