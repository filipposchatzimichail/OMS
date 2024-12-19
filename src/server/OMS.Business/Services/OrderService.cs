using OMS.Business.Dtos;
using OMS.Business.Services.Generics;
using OMS.DataAccess.Entities;
using OMS.DataAccess.Repositories;
using System.Runtime.CompilerServices;

namespace OMS.Business.Services;

public class OrderService : Service<Order>, IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IMenuItemRepository _menuItemRepository;

    public OrderService(IOrderRepository repository, ICustomerRepository customerRepository, IOrderItemRepository orderItemRepository, IMenuItemRepository menuItemRepository) : base(repository)
    {
        _orderRepository = repository;
        _customerRepository = customerRepository;
        _orderItemRepository = orderItemRepository;
        _menuItemRepository = menuItemRepository;
    }
    public override Task<Order> Create(Order item)
    {
        item.Id = Guid.NewGuid();
        return base.Create(item);
    }

    public async override Task<IEnumerable<object>> GetAllAsDtoAsyc()
    {
        var orders = _orderRepository.GetAll().ToList();

        var result = new List<OrderDto>();

        foreach (var order in orders)
        {
            var cOrder = new OrderDto
            {
                Id = order.Id,
                Status = order.Status,
                Basket = new List<OrderItemDto>(),
                CreatedDate = order.CreatedDate,
                TotalPrice = order.TotalPrice,
                IsDelivery = order.IsDelivery,
                UpdatedDate = order.UpdatedDate,
                CustomerId = order.CustomerId,
                Customer = _customerRepository.Get(order.CustomerId)
            };

            var items = _orderItemRepository.GetAll().Where(p => p.OrderId == order.Id).ToList();
            foreach (var item in items)
            {
                cOrder.Basket.Add(new OrderItemDto { Item = item.Item, Quantity = item.Quantity });
            }


            result.Add(cOrder);
        }

        return await Task.FromResult(result);
    }

    public async override Task<Order> CreateFromDto(object dto)
    {
        if (dto.GetType() == typeof(OrderCreateDto))
        {          
            var orderDto = (OrderCreateDto)dto;
            var customer = new Customer { 
                Id = Guid.NewGuid(),
                FirstName = orderDto.FirstName,
                LastName = orderDto.LastName,
                PhoneNumber = orderDto.PhoneNumber,
                AddressLine = orderDto.AddressLine,
                Postcode = orderDto.Postcode,
                SpecialInstructions = orderDto.SpecialInstructions              
            };

            _customerRepository.Add(customer);
            _customerRepository.Save();


            var isDelivery = (!String.IsNullOrEmpty(orderDto.AddressLine) && !String.IsNullOrEmpty(orderDto.Postcode));
            var now = DateTime.UtcNow;

            Order order = new Order() { 
                Id = Guid.NewGuid(),
                Status = isDelivery ? OrderStatus.Delivery_Pending : OrderStatus.Pickup_Pending,
                CreatedDate = now,
                UpdatedDate = now,
                CustomerId = customer.Id,
                TotalPrice = orderDto.TotalPrice,
                IsDelivery = isDelivery
            };

            _orderRepository.Add(order);
            _orderRepository.Save();

            foreach (var item in orderDto.Basket)
            {

                var menuItem = _menuItemRepository.Get(item.Item.Id);

                var orderItem = new OrderItem
                {
                    Id = Guid.NewGuid(),
                    ItemId = menuItem.Id,
                    Item = menuItem,
                    OrderId = order.Id,
                    Order = order,
                    Quantity = item.Quantity
                };

                _orderItemRepository.Add(orderItem);
                _orderItemRepository.Save();
            }
            return await Task.FromResult(order);
        }

        return await base.CreateFromDto(dto);
    }
}

public interface IOrderService : IService<Order>
{
}