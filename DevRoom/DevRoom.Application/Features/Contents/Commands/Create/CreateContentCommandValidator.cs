using DevRoom.Application.Contracts.Persistence;
using DevRoom.Domain.Entities;
using FluentValidation;

namespace DevRoom.Application.Features.Contents.Commands.Create
{
    public class CreateContentCommandValidator : AbstractValidator<CreateContentCommand>
    {
        private readonly IAsyncRepository<Content> _contentRepository;

        public CreateContentCommandValidator(IAsyncRepository<Content> contentRepository)
        {
            _contentRepository = contentRepository;
        }
    }
}
