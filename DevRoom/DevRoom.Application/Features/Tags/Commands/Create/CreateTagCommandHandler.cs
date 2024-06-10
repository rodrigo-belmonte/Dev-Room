using AutoMapper;
using DevRoom.Application.Contracts.Persistence;
using DevRoom.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DevRoom.Application.Features.Tags.Commands.Create
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, CreateTagCommandResponse>
    {
        private readonly ITagRepository _TagRepository;
        private readonly IMapper _mapper;

        public CreateTagCommandHandler(IMapper mapper, ITagRepository TagRepository)
        {
            _mapper = mapper;
            _TagRepository = TagRepository;
        }

        public async Task<CreateTagCommandResponse> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var createTagCommandResponse = new CreateTagCommandResponse();

            var validator = new CreateTagCommandValidator(_TagRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createTagCommandResponse.Success = false;
                createTagCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createTagCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createTagCommandResponse.Success)
            {
                var Tag = _mapper.Map<Tag>(request);
                createTagCommandResponse.Tag = _mapper.Map<CreateTagDto>(await _TagRepository.AddAsync(Tag));
            }

            return createTagCommandResponse;
        }
    }
}
