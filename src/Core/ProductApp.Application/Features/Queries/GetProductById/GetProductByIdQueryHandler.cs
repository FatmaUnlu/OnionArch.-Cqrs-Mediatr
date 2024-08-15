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

namespace ProductApp.Application.Features.Queries.GetProductById
{
    public class GetProductByIdQueryHandler :IRequestHandler<GetProductByIdQuery, ServiceResponse<ProductViewDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
                _productRepository = productRepository;
                _mapper = mapper;
        }
        public async Task<ServiceResponse<ProductViewDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            var viewResult = _mapper.Map<ProductViewDto>(product);

            return new ServiceResponse<ProductViewDto>(viewResult);
        }
    }
}
