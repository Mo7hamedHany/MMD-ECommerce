using AutoMapper;
using MediatR;
using MMD_ECommerce.Core.DTOs;
using MMD_ECommerce.Core.Features.Products.Query.Models;
using MMD_ECommerce.Infrastructure.Specifications.Products;
using MMD_ECommerce.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_ECommerce.Core.Features.Products.Query.Handlers
{
    public class ProductQueryHandler : IRequestHandler<GetProductsQuery, PaginatedResultDto<ProductToReturnDto>>
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
    }
}
