import { inject, Injectable, signal } from '@angular/core';
import { ApiService } from './api.service';
import { Order } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  orders = signal<Order[]>([]);
  private apiService = inject(ApiService);

  constructor() {
    this.apiService.getOrders().subscribe({
      next: (response) => {
        console.log(response);
          response.forEach(order => {       
          this.orders.update(items => [...items, order]);
       });             
      },
      error: () => {}
    });
  }

  createOrder(order: any) {
    console.log(order);
    this.apiService.createOrder(order).subscribe({
      next: (response) => {
        alert("New Order has been successfully created");
      },
      error: () => {}
    });
  }
}
