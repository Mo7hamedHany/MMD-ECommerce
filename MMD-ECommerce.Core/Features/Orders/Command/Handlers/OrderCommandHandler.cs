using AutoMapper;
using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.Features.Orders.Command.Models;
using MMD_ECommerce.Data.Models.Orders;
using MMD_ECommerce.Service.Abstractions;

namespace MMD_ECommerce.Core.Features.Orders.Command.Handlers
{
    public class OrderCommandHandler : ResponseHandler, IRequestHandler<CreateOrderCommand, Response<string>>
    {

        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderCommandHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);

            var orderResult = await _orderService.CreateOrderAsync(order);

            switch (orderResult)
            {
                case "OrderIsNull": return BadRequest<string>("Order is sent with a null value");
                case "BasketNotFound": return UnprocessableEntity<string>("The target basket is not found");
                case "BasketItemsNotFound": return NotFound<string>("Basket Items not Found");
                case "NoDeliveryMethodSelected": return BadRequest<string>("No Delivery Method Selected");
                case "InvalidDeliveryMethodId": return UnprocessableEntity<string>("Invalid Delivery Method");
                case "Success": return Success("Order Created Successfully");
                default: return BadRequest<string>();
            }
        }
    }
}
