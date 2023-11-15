using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApoloHealth.Application.UseCases.AddressOperations.Create;

internal class CreateAddressHandler : IRequestHandler<CreateAddressRequest, CreateAddressResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAddressRepository _addressRepository;
    private readonly IMapper _mapper;
    public CreateAddressHandler(IUnitOfWork unitOfWork, IAddressRepository addressRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _addressRepository = addressRepository;
        _mapper = mapper;
    }
    public async Task<CreateAddressResponse> Handle(CreateAddressRequest request, CancellationToken cancellationToken)
    {
        var address = _mapper.Map<Address>(request);
        _addressRepository.Create(address);
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<CreateAddressResponse>(address);
    }
}
