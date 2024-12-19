import { inject, Injectable, signal } from '@angular/core';
import { MenuItem } from '../models/models';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class MenuService {  
  menuItems = signal<MenuItem[]>([]);
  private apiService = inject(ApiService);
  
  constructor() {
    this.apiService.getMenuItems().subscribe({
      next: (response) => {
        //console.log(response);
        response.forEach(menuItem => {       
          this.menuItems.update(items => [...items, menuItem]);
        });             
      },
      error: () => {}
    });
  }

  updateMenuItem(menuItem: MenuItem) {
    this.apiService.updateMenuItem(menuItem).subscribe({
      next: (response) => {
        if (response === true) {
          this.menuItems.update(items => items.map(item => item.id === menuItem.id ? menuItem : item));
          alert("Menu has been successfully updated");
        }

      },
      error: () => {}
    });
  }
  deleteMenuItem(menuItem: MenuItem) {
      
    this.apiService.deleteMenuItem(menuItem).subscribe({
      next: (response) => {
        if (response === true) {
          this.menuItems.update(items => items.filter(item => item.id !== menuItem.id));
          alert("Menu has been successfully deleted");
        }

      },
      error: () => {
        
      }
    });
  }

  createMenuItem(menuItem: any) {
    this.apiService.createMenuItem(menuItem).subscribe({
      next: (response) => {
        const newMenuItem : any = response;
        this.menuItems.update(items => [...items, newMenuItem]);
        alert("New Menu Item has been successfully created");
      },
      error: () => {
        
      }
    });
  }

}
