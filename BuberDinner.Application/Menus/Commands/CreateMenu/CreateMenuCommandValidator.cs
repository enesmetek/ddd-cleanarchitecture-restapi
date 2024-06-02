using FluentValidation;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
    {
        public CreateMenuCommandValidator()
        {
            RuleFor(x => x.HostId)
                .NotEmpty().WithMessage("HostId is required");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Sections)
                .NotEmpty().WithMessage("Sections is required");
        }
    }
}
