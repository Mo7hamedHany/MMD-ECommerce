using AutoMapper;
using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.DTOs.Order;
using MMD_ECommerce.Core.Features.Orders.Query.Models;
using MMD_ECommerce.Data.Models.Orders;
using MMD_ECommerce.Service.Abstractions;

namespace MMD_ECommerce.Core.Features.Orders.Query.Handlers
{
    public class OrdersQueryHandler : ResponseHandler,
        IRequestHandler<GetDeliveryMethodsQuery, Response<IEnumerable<DeliveryMethods>>>,
    IRequestHandler<GetOrdersForUserQuery, Response<IEnumerable<OrderResultDto>>>,
    IRequestHandler<GetAllOrdersQuery, Response<IEnumerable<OrderResultDto>>>
    {

        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrdersQueryHandler(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        public async Task<Response<IEnumerable<DeliveryMethods>>> Handle(GetDeliveryMethodsQuery request, CancellationToken cancellationToken)
        {
            var deliveryMethods = await _orderService.GetDeliveryMethodsAsync();

            if (deliveryMethods == null) return NotFound<IEnumerable<DeliveryMethods>>("No Delivery Methods found");

            return Success(deliveryMethods);
        }

        public async Task<Response<IEnumerable<OrderResultDto>>> Handle(GetOrdersForUserQuery request, CancellationToken cancellationToken)
        {
            if (request.Email is null) return BadRequest<IEnumerable<OrderResultDto>>();

            var orders = await _orderService.GetOrdersForUser(request.Email);
            if (orders == null) return NotFound<IEnumerable<OrderResultDto>>("No Orders Found");

            var mappedOrders = _mapper.Map<IEnumerable<OrderResultDto>>(orders);

            return Success(mappedOrders);
        }

        public async Task<Response<IEnumerable<OrderResultDto>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderService.GetAllSystemOrders();
            if (orders == null) return NotFound<IEnumerable<OrderResultDto>>("No Orders Found");

            var mappedOrders = _mapper.Map<IEnumerable<OrderResultDto>>(orders);

            return Success(mappedOrders);
        }
    }
}
