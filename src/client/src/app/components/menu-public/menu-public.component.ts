import { Component, computed, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MenuItem } from '../../models/models';
import { OrderComponent } from '../order/order.component';
import { BasketService } from '../../services/basket.service';
import { MenuService } from '../../services/menu.service';
import { NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-menu-public',
  standalone: true,
  imports: [CommonModule, RouterModule, OrderComponent, NgbTooltipModule],
  templateUrl: './menu-public.component.html',
  styleUrl: './menu-public.component.scss'
})
export class MenuPublicComponent {

  basketService = inject(BasketService);
  menuService = inject(MenuService);
   
  addToBasket(menuItem: MenuItem) {
    const items = this.basketService.basketItems();
    const found = items.find(p=>p.item.id === menuItem.id);
    
    if (found) {
      this.basketService.updateBasketItem(found.item, found.quantity+1);
    }
    else {
      this.basketService.addToBasket(menuItem);
    }
  }

  removeFromBasket(menuItem: MenuItem) {
    const items = this.basketService.basketItems();
    const found = items.find(p=>p.item.id === menuItem.id);
    
    if (found) {
      if (found && found.quantity > 1) {
        this.basketService.updateBasketItem(found.item, found.quantity-1);
      }
      else {
        this.basketService.removeFromBasket(found.item);
      }      
    }
  }

}




