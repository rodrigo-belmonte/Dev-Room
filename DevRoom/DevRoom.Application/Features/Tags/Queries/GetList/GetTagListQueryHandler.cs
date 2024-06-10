using AutoMapper;
using DevRoom.Application.Contracts.Persistence;
using DevRoom.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevRoom.Application.Features.Tags.Queries.GetList
{
    public class GetTagListQueryHandler : IRequestHandler<GetTagListQuery, List<TagListVm>>
    {
        private readonly IAsyncRepository<Tag> _TagRepository;
        private readonly IMapper _mapper;

        public GetTagListQueryHandler(IMapper mapper, IAsyncRepository<Tag> TagRepository)
        {
            _mapper = mapper;
            _TagRepository = TagRepository;
        }

        public async Task<List<TagListVm>> Handle(GetTagListQuery request, CancellationToken cancellationToken)
        {
            var allTags = (await _TagRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<TagListVm>>(allTags);
        }
    }
}