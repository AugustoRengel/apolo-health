using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System.Reflection;

namespace ApoloHealth.Application.UseCases.CustomerOperations.Update;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    public UpdateCustomerHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _customerRepository = customerRepository;
        _mapper = mapper;
    }
    public async Task<UpdateCustomerResponse> Handle(UpdateCustomerRequest command, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.Get(command.Id, cancellationToken);

        if (customer == null) { return default; }
        var customerUpdate = _mapper.Map<Customer>(command);

        if (customerUpdate.LastAppointment != null) { customer.LastAppointment = customerUpdate.LastAppointment; }
        if (!string.IsNullOrEmpty(customerUpdate.HealthInsurance)) { customer.HealthInsurance = customerUpdate.HealthInsurance; }
        if (!string.IsNullOrEmpty(customerUpdate.Name)) { customer.Name = customerUpdate.Name; }
        if (!string.IsNullOrEmpty(customerUpdate.CPF)) { customer.CPF = customerUpdate.CPF; }
        if (customerUpdate.BirthDate != null) { customer.BirthDate = customerUpdate.BirthDate; }
        if (!string.IsNullOrEmpty(customerUpdate.Email)) { customer.Email = customerUpdate.Email; }
        if (!string.IsNullOrEmpty(customerUpdate.Phone)) { customer.Phone = customerUpdate.Phone; }
        if (customerUpdate.Gender != null) { customer.Gender = customerUpdate.Gender; }
        if (!string.IsNullOrEmpty(customerUpdate.Nationality)) { customer.Nationality = customerUpdate.Nationality; }
        if (customerUpdate.MaritalStatus != null) { customer.MaritalStatus = customerUpdate.MaritalStatus; }
        if (customerUpdate.Addresses != null) { customer.Addresses = customerUpdate.Addresses; }

        _customerRepository.Update(customer);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<UpdateCustomerResponse>(customer);
    }
}
