import { Component, computed, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { UserService } from '../../services/user.service';
import { MenuAdminComponent } from '../menu-admin/menu-admin.component';
import { MenuPublicComponent } from '../menu-public/menu-public.component';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [CommonModule, RouterModule, MenuAdminComponent, MenuPublicComponent],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.scss'
})
export class MenuComponent {  
  userService = inject(UserService);  
}




