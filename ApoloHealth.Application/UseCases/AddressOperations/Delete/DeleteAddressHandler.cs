using ApoloHealth.Application.UseCases.AddressOperations.Delete;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.AddressOperations.Delete;

public class DeleteAddressHandler : IRequestHandler<DeleteAddressRequest, DeleteAddressResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAddressRepository _addressRepository;
    private readonly IMapper _mapper;
    public DeleteAddressHandler(IUnitOfWork unitOfWork, IAddressRepository addressRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _addressRepository = addressRepository;
        _mapper = mapper;
    }
    public async Task<DeleteAddressResponse> Handle(DeleteAddressRequest request, CancellationToken cancellationToken)
    {
        var address = await _addressRepository.Get(request.Id, cancellationToken);

        if (address == null) { return default; }

        _addressRepository.Delete(address);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<DeleteAddressResponse>(address);
    }
}
