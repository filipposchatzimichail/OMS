import { Component, computed, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { BasketItem } from '../../models/models';
import { FormsModule } from '@angular/forms';
import { BasketService } from '../../services/basket.service';
import { OrderService } from '../../services/order.service';

@Component({
  selector: 'app-order',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule],
  templateUrl: './order.component.html',
  styleUrl: './order.component.scss'
})
export class OrderComponent {
  basketService = inject(BasketService);
  orderService = inject(OrderService);

  save() {
    const firstName = document.getElementById("new-first-name") as HTMLInputElement;
    const lastName = document.getElementById("new-last-name") as HTMLInputElement;
    const addressLine = document.getElementById("new-address-line") as HTMLInputElement;
    const postcode = document.getElementById("new-postcode") as HTMLInputElement;
    const phoneNumber = document.getElementById("new-phone-number") as HTMLInputElement;
    const specialInstructions = document.getElementById("new-special-instructions") as HTMLInputElement;

    this.orderService.createOrder({ 
      totalPrice: this.basketService.totalPrice(),
      basket: this.basketService.basketItems(),
      firstName: firstName.value, 
      lastName: lastName.value, 
      addressLine: addressLine.value, 
      postcode: postcode.value, 
      phoneNumber: phoneNumber.value,
      specialInstructions: specialInstructions.value
    });

    firstName.value = "";
    lastName.value = "";
    addressLine.value = "";
    postcode.value = "";
    phoneNumber.value = "";
    specialInstructions.value = "";
    
  }
}
