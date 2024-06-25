using AutoMapper;
using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.Features.Products.Command.Models;
using MMD_ECommerce.Data.Models.Products;
using MMD_ECommerce.Service.Abstractions;

namespace MMD_ECommerce.Core.Features.Products.Command.Handlers
{
    public class ProductCommandHandler : ResponseHandler,
        IRequestHandler<CreateProductCommand, Response<string>>,
        IRequestHandler<DeleteProductCommand, Response<string>>,
        IRequestHandler<EditProductCommand, Response<string>>
    {

        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductCommandHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var mappedProduct = _mapper.Map<Product>(request);

            mappedProduct.MerchantEmail = request.MerchantEmail;

            var productResult = await _productService.CreateProduct(mappedProduct);

            if (productResult is null) return BadRequest<string>();

            return Success(productResult);
        }

        public async Task<Response<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == 0) return BadRequest<string>("Can't send Id with 0");

            var result = await _productService.DeleteProduct(request.Id);

            if (result == "Success") return Deleted<string>();
            else if (result == "NotFound") return NotFound<string>("Product is not found");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == 0 || request == null) return BadRequest<string>();

            var mappedProduct = _mapper.Map<Product>(request);

            var editResult = await _productService.EditProduct(mappedProduct);

            if (editResult is null) return BadRequest<string>();
            else if (editResult == "NotFound") return NotFound<string>("Product to be edit is not available right now");
            else return Success("Edited Successfully");
        }
    }
}
