import { Component, computed, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MenuItem } from '../../models/models';
import { MenuService } from '../../services/menu.service';
import { NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-menu-admin',
  standalone: true,
  imports: [CommonModule, RouterModule, NgbTooltipModule],
  templateUrl: './menu-admin.component.html',
  styleUrl: './menu-admin.component.scss'
})
export class MenuAdminComponent {
  menuService = inject(MenuService);
  editingMenuItemIndex = -1;
  addingNewItemInProgress = false;
  
  edit(index : number) {
    this.editingMenuItemIndex = index;
  }

  editingInProgress(index : number) {
    return this.editingMenuItemIndex === index;
  }

  save(index: number, item: MenuItem) {
    if (confirm("Are you sure you want to update this menu item?")) {
      const name = (document.getElementById("menu-item-name-" + index) as HTMLInputElement).value;
      const price = Number((document.getElementById("menu-item-price-" + index) as HTMLInputElement).value);
  
      item.name = name; 
      item.price = price;
  
      this.menuService.updateMenuItem(item);        
      this.editingMenuItemIndex = -1;      
    }
  }

  addNew() {
    const name = document.getElementById("menu-item-name-new") as HTMLInputElement;
    const price = document.getElementById("menu-item-price-new") as HTMLInputElement;

    this.menuService.createMenuItem({ name: name.value, price: Number(price.value) });

    name.value = "";
    price.value = "0";

    this.addingNewItemInProgress = false;
  }

  delete(item: MenuItem) { 
    if (confirm("Are you sure you want to delete this menu item?")) {
      this.menuService.deleteMenuItem(item);
      this.editingMenuItemIndex = -1;
    }  
  }
  
  cancelEditing() {
    this.editingMenuItemIndex = -1;
  }
}




