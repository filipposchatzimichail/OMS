import { Routes } from '@angular/router';
import { MenuComponent } from './components/menu/menu.component';
import { OrderComponent } from './components/order/order.component';
import { OrderListComponent } from './components/order-list/order-list.component';

export const routes: Routes = [
    {
        path: '',
        component: MenuComponent
    },
    {
        path: 'menu',
        component: MenuComponent
    },
    {
        path: 'order',
        component: OrderComponent
    },
    {
        path: 'orders',
        component: OrderListComponent
    }
];
