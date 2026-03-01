using FluentValidation;
using item_service.ports.dto.item;

namespace item_service.webapi.adapters.input.validators
{
    public class CompletarItemValidator : AbstractValidator<CompletarItemRequest>
    {
        public CompletarItemValidator()
        {
            RuleFor(x => x.ItemId).NotEmpty().WithMessage("El ID del ítem es obligatorio.");
        }
    }
}
