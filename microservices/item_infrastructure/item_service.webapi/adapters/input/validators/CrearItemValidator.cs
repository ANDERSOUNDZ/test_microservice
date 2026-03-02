using FluentValidation;
using item_service.ports.dto.item;

namespace item_service.webapi.adapters.input.validators
{
    public class CrearItemValidator : AbstractValidator<CrearItemRequest>
    {
        public CrearItemValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("El título es obligatorio.")
                .MaximumLength(100).WithMessage("El título es muy largo.");

            RuleFor(x => x.FechaEntrega)
                .GreaterThanOrEqualTo(DateTime.Today)
                .WithMessage("La fecha no puede ser anterior a hoy.");
        }
    }
}
