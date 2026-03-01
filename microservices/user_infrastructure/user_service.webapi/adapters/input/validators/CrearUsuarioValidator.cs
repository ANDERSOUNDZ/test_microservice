using FluentValidation;
using user_service.ports.dto.user;

namespace user_service.webapi.adapters.input.validators
{
    public class CrearUsuarioValidator : AbstractValidator<CrearUsuarioRequest>
    {
        public CrearUsuarioValidator()
        {
            RuleFor(x => x.Username).NotEmpty().MinimumLength(3);
            RuleFor(x => x.NombreCompleto).NotEmpty();
        }
    }
}
