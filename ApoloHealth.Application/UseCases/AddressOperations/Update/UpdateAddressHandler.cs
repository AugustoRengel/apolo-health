using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApoloHealth.Application.UseCases.AddressOperations.Update;

public class UpdateAddressHandler : IRequestHandler<UpdateAddressRequest, UpdateAddressResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAddressRepository _addressRepository;
    private readonly IMapper _mapper;
    public UpdateAddressHandler(IUnitOfWork unitOfWork, IAddressRepository addressRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _addressRepository = addressRepository;
        _mapper = mapper;
    }
    public async Task<UpdateAddressResponse> Handle(UpdateAddressRequest command, CancellationToken cancellationToken)
    {
        var address = await _addressRepository.Get(command.Id, cancellationToken);

        if (address == null) { return default; }
        var addressUpdate = _mapper.Map<Address>(command);

        if (!string.IsNullOrEmpty(addressUpdate.Street)) { address.Street = addressUpdate.Street; }
        if (!string.IsNullOrEmpty(addressUpdate.City)) { address.City = addressUpdate.City; }
        if (!string.IsNullOrEmpty(addressUpdate.State)) { address.State = addressUpdate.State; }
        if (!string.IsNullOrEmpty(addressUpdate.PostalCode)) { address.PostalCode = addressUpdate.PostalCode; }
        if (!string.IsNullOrEmpty(addressUpdate.Country)) { address.Country = addressUpdate.Country; }
        if (addressUpdate.PersonId != null) { address.PersonId = addressUpdate.PersonId; }

        _addressRepository.Update(address);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<UpdateAddressResponse>(address);
    }
}
