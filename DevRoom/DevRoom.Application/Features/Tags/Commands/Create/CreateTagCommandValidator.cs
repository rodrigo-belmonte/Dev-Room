using DevRoom.Application.Contracts.Persistence;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace DevRoom.Application.Features.Tags.Commands.Create
{
    public class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
    {
        private readonly ITagRepository _TagRepository;

        public CreateTagCommandValidator(ITagRepository TagRepository)
        {
            _TagRepository = TagRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters.");

            RuleFor(e => e)
                .MustAsync(TagNameUnique)
                .WithMessage("An Tag with the same name already exists.");
        }

        private async Task<bool> TagNameUnique(CreateTagCommand e, CancellationToken token)
        {
            return !(await _TagRepository.IsTagNameUnique(e.Name));
        }
    }
}
