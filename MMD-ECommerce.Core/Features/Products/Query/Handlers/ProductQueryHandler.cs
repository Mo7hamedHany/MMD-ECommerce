using AutoMapper;
using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.DTOs;
using MMD_ECommerce.Core.DTOs.Product;
using MMD_ECommerce.Core.Features.Products.Query.Models;
using MMD_ECommerce.Infrastructure.Specifications.Products;
using MMD_ECommerce.Service.Abstractions;

namespace MMD_ECommerce.Core.Features.Products.Query.Handlers
{
    public class ProductQueryHandler : ResponseHandler,
        IRequestHandler<GetProductsQuery, PaginatedResultDto<ProductToReturnDto>>,
        IRequestHandler<GetProductByIdQuery, Response<ProductToReturnDto>>,
        IRequestHandler<GetProductsForMerchantQuery, Response<IEnumerable<ProductToReturnDto>>>

    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<PaginatedResultDto<ProductToReturnDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {

            var SpecsMapping = _mapper.Map<ProductSpecificationParameters>(request);

            var products = await _productService.GetProductsWithSpecs(SpecsMapping);
            var mappedProducts = _mapper.Map<IEnumerable<ProductToReturnDto>>(products);

            return new PaginatedResultDto<ProductToReturnDto>()
            {
                Data = mappedProducts,
                PageIndex = SpecsMapping.PageIndex,
                PageSize = SpecsMapping.PageSize,
                TotalCount = mappedProducts.Count()

            };
        }

        public async Task<Response<ProductToReturnDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {

            if (request == null) return BadRequest<ProductToReturnDto>();
            var product = await _productService.GetProduct(request.Id);
            if (product == null) return NotFound<ProductToReturnDto>("Product is not found");

            var mappedProduct = _mapper.Map<ProductToReturnDto>(product);

            return Success(mappedProduct);
        }

        public async Task<Response<IEnumerable<ProductToReturnDto>>> Handle(GetProductsForMerchantQuery request, CancellationToken cancellationToken)
        {
            if (request == null) return BadRequest<IEnumerable<ProductToReturnDto>>();

            var products = await _productService.GetProductsOfMerchant(request.Email);

            if (products == null) return NotFound<IEnumerable<ProductToReturnDto>>("No products found for this merchant");

            var mappedProducts = _mapper.Map<IEnumerable<ProductToReturnDto>>(products);

            return Success(mappedProducts);
        }
    }
}
