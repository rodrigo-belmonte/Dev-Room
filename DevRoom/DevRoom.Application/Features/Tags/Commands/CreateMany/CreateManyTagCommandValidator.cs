using DevRoom.Application.Contracts.Persistence;
using FluentValidation;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DevRoom.Application.Features.Tags.Commands.CreateMany
{
    public class CreateManyTagCommandValidator : AbstractValidator<CreateManyTagCommand>
    {
        private readonly ITagRepository _TagRepository;
        public CreateManyTagCommandValidator(ITagRepository tagRepository)
        {
            _TagRepository = tagRepository;
        }
    }
}
