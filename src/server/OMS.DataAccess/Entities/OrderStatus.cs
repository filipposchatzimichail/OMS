namespace OMS.DataAccess.Entities;

public enum OrderStatus
{
    Pickup_Pending,
    Pickup_Preparing,
    Pickup_Ready_For_Pickup,
    Delivery_Pending,
    Delivery_Preparing,
    Delivery_Ready_For_Delivery,
    Delivery_Out_For_Delivery,
    Delivery_Delivered
}
