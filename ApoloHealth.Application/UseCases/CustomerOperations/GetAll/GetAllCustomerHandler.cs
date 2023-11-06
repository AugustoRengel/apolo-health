using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApoloHealth.Application.UseCases.CustomerOperations.GetAll;

public sealed class GetAllCustomerHandler : IRequestHandler<GetAllCustomerRequest, List<GetAllCustomerResponse>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    public GetAllCustomerHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }
    public async Task<List<GetAllCustomerResponse>> Handle(GetAllCustomerRequest request, CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.GetAll(cancellationToken);
        return _mapper.Map<List<GetAllCustomerResponse>>(customers);
    }
}