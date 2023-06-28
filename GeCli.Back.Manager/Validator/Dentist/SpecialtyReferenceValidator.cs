using FluentValidation;
using GeCli.Back.Shared.ModelView.Employees;

namespace GeCli.Back.Domain.Interfaces;

public class SpecialtyReferenceValidator : AbstractValidator<SpecialtyReference>
{
    private readonly ISpecialtyRepository _specialtyRepository;
    public SpecialtyReferenceValidator(ISpecialtyRepository repository) 
    {
        this._specialtyRepository = repository;
        RuleFor(p => p.Id).NotEmpty().NotNull().GreaterThan(0)
            .MustAsync(async (id,_) => 
            { 
                return await ExistOnBase(id); 
            })
            .WithMessage("Especialidade não cadastradas.");
    }

    private async Task<bool> ExistOnBase(int id)
    {
        return await _specialtyRepository.ExistAsync(id);
    }
}
