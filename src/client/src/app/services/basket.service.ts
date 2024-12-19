import { Injectable, signal } from '@angular/core';
import { MenuItem, BasketItem } from '../models/models';

@Injectable({
  providedIn: 'root'
})


export class BasketService { 
  basketItems = signal<BasketItem[]>([]);
  
  addToBasket(item: MenuItem) : void {
    this.basketItems.update(items => [...items, { item, quantity: 1 }]);
    localStorage.setItem('basket', JSON.stringify(this.basketItems()));
  }

  removeFromBasket(menuItem: MenuItem) : void {
    this.basketItems.update(items => items.filter(item => item.item.id !== menuItem.id));
    localStorage.setItem('basket', JSON.stringify(this.basketItems()));
  }

  updateBasketItem(menuItem: MenuItem, quantity: number) {
    this.basketItems.update(items => items.map(item => item.item.id === menuItem.id ? {item: menuItem, quantity } : item));
    localStorage.setItem('basket', JSON.stringify(this.basketItems()));
  }

  totalPrice() {
    var total = 0;

    for (const item of this.basketItems()){
      total += this.itemPrice(item);
    }

    return total;
  }

  itemPrice(item: BasketItem) {
    return item.quantity * item.item.price;
  }
}
