using FluentValidation;

namespace ApoloHealth.Application.UseCases.EmployeeOperations.GetAll;

public class GetAllEmployeeValidator : AbstractValidator<GetAllEmployeeRequest>
{
    public GetAllEmployeeValidator()
    {
        // without validation
    }

}
