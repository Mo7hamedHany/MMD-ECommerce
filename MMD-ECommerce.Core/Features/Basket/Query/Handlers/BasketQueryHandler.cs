using AutoMapper;
using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.DTOs.Basket;
using MMD_ECommerce.Core.Features.Basket.Query.Models;
using MMD_ECommerce.Service.Abstractions;

namespace MMD_ECommerce.Core.Features.Basket.Query.Handlers
{
    public class BasketQueryHandler : ResponseHandler, IRequestHandler<GetBasketQuery, Response<BasketDto>>
    {

        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketQueryHandler(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        public async Task<Response<BasketDto>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            var basket = await _basketService.GetBasketAsync(request.Id);

            if (basket == null) return NotFound<BasketDto>("Basket is Not Found");

            var mappedBasket = _mapper.Map<BasketDto>(basket);

            return Success(mappedBasket);
        }
    }
}
