using AutoMapper;
using DevRoom.Application.Contracts.Persistence;
using DevRoom.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DevRoom.Application.Features.Tags.Commands.CreateMany
{
    public class CreateManyTagCommandHandler : IRequestHandler<CreateManyTagCommand, CreateManyTagCommandResponse>
    {
        private readonly ITagRepository _TagRepository;
        private readonly IMapper _mapper;

        public CreateManyTagCommandHandler(IMapper mapper, ITagRepository TagRepository)
        {
            _mapper = mapper;
            _TagRepository = TagRepository;
        }

        public async Task<CreateManyTagCommandResponse> Handle(CreateManyTagCommand request, CancellationToken cancellationToken)
        {
            var CreateManyTagCommandResponse = new CreateManyTagCommandResponse();

            var tags = await RemoveTagsAlreadyExists(request.Tags);

            await _TagRepository.AddRangeAsync(tags);

            CreateManyTagCommandResponse.Success = true;
            return CreateManyTagCommandResponse;
        }

        private async Task<IList<Tag>> RemoveTagsAlreadyExists(IList<string> tags)
        {
            var tagsToInclude = new List<Tag>();
            foreach (var tag in tags)
            {
                if (!await _TagRepository.IsTagNameUnique(tag))
                {
                    var Tag = new Tag()
                    {
                        Name = tag
                    };
                    tagsToInclude.Add(Tag);
                }
            }
            return tagsToInclude;
        }
    }
}
