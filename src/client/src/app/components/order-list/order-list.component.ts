import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { RouterModule } from '@angular/router';
import { OrderService } from '../../services/order.service';

@Component({
  selector: 'app-order-list',
  imports: [CommonModule, RouterModule],
  templateUrl: './order-list.component.html',
  styleUrl: './order-list.component.scss'
})
export class OrderListComponent {
  orderService = inject(OrderService);
}
