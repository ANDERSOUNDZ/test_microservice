using FluentValidation;
using item_service.ports.dto.item;

namespace item_service.webapi.adapters.input.validators
{
    public class CrearItemValidator : AbstractValidator<CrearItemRequest>
    {
        public CrearItemValidator()
        {
            RuleFor(x => x.Titulo).NotEmpty().WithMessage("El título es obligatorio.");
            RuleFor(x => x.FechaEntrega).GreaterThan(DateTime.Now).WithMessage("La fecha debe ser futura.");
        }
    }
}
