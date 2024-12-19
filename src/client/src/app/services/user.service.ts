import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  isLoggedIn = signal(false);
  user = signal('Admin User');

  login() {
    if (!this.isLoggedIn()){
      this.isLoggedIn.set(true);
      this.user.set("Admin User");
    }
          
  }
  logout() {
    if (this.isLoggedIn()){
      this.isLoggedIn.set(false);
      this.user.set("")
    }
  }

}
