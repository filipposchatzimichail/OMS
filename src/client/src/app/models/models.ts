
export interface BasketItem {
  item: MenuItem;
  quantity: number;  
}

export interface MenuItem {
    id: string;
    name: string;
    price: number;
}

export interface Order {
  id: string;
  status: number;
  totalPrice: number;
  createdDate: string;
  updatedDate: string;
  customerId: string;
  customer: any;
  basket: any;
  isDelivery: boolean;
}