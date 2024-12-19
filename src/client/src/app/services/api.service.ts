import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MenuItem, Order } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private menuItemApiUrl = 'api/menu-item';
  private orderApiUrl = 'api/order';

  constructor(private http: HttpClient) { }

  getMenuItems() {
    return this.http.get<MenuItem[]>(this.menuItemApiUrl);
  }

  updateMenuItem(item: MenuItem) {
    return this.http.put(this.menuItemApiUrl + '/update', item);
  }

  deleteMenuItem(item: MenuItem) {   
    return this.http.post(this.menuItemApiUrl + '/delete', {id: item.id});
  }
  createMenuItem(item: any) {   
    return this.http.post(this.menuItemApiUrl + '/create', {name: item.name, price: item.price});
  }

  getOrders() {
    return this.http.get<Order[]>(this.orderApiUrl);
  }

  // updateOrder(item: MenuItem) {
  //   return this.http.put(this.orderApiUrl + '/update', item);
  // }

  // deleteOrder(item: MenuItem) {   
  //   return this.http.post(this.orderApiUrl + '/delete', {id: item.id});
  // }
  createOrder(order: any) {   
    return this.http.post(this.orderApiUrl + '/create', {
      totalPrice: order.totalPrice,
      firstName: order.firstName, 
      lastName: order.lastName, 
      addressLine: order.addressLine, 
      postcode: order.postcode, 
      phoneNumber: order.phoneNumber,
      specialInstructions: order.specialInstructions,
      basket: order.basket
    });
  }

}


