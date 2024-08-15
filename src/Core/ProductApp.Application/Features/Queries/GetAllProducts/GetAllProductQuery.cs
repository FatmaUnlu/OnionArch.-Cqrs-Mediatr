using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProductApp.Application.Dto;
using ProductApp.Application.Interfaces;
using ProductApp.Application.Wrappers;

namespace ProductApp.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductQuery :IRequest<ServiceResponse<List<ProductViewDto>>>
    {

        public class GetAllProductQueryHandler :IRequestHandler<GetAllProductQuery, ServiceResponse<List<ProductViewDto>>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                    _productRepository = productRepository;
                    _mapper = mapper;
            }
            public async Task<ServiceResponse<List<ProductViewDto>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetAllAsync();

                var viewModel = _mapper.Map<List<ProductViewDto>>(products);

                return new ServiceResponse<List<ProductViewDto>>(viewModel);
            }
        }
    }
}
