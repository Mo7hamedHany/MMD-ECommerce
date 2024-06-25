using AutoMapper;
using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.Features.Basket.Command.Models;
using MMD_ECommerce.Service.Abstractions;
using coreBasket = MMD_ECommerce.Data.Models.Basket.Basket;

namespace MMD_ECommerce.Core.Features.Basket.Command.Handlers
{
    public class BasketCommandHandler : ResponseHandler,
        IRequestHandler<UpdateBasketCommand, Response<string>>,
        IRequestHandler<DeleteBasketCommand, Response<string>>
    {

        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketCommandHandler(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
        {
            var mappedBasket = _mapper.Map<coreBasket>(request);

            var basketResult = await _basketService.UpdateBasketAsync(mappedBasket);

            if (basketResult == "Success") return Success("BasketUpdatedSuccessfully");
            else if (basketResult == "ProductNotFound") return BadRequest<string>("Product is not available right now");
            else return BadRequest<string>("There's an Error in basket update. please check your inputs");
        }

        public async Task<Response<string>> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            var result = await _basketService.DeleteBasketAsync(request.Id);

            if (result == "Success") return Deleted<string>();
            else if (result == "NotFound") return NotFound<string>("Basket is not found");
            else return BadRequest<string>();
        }
    }
}
