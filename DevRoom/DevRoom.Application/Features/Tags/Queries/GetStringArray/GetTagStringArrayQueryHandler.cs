using DevRoom.Application.Contracts.Persistence;
using DevRoom.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevRoom.Application.Features.Tags.Queries.GetStringArray
{
    public class GetTagStringArrayQueryHandler : IRequestHandler<GetTagStringArrayQuery, IEnumerable<string>>
    {
        private readonly ITagRepository _TagRepository;
        //private readonly IMapper _mapper;

        public GetTagStringArrayQueryHandler(ITagRepository TagRepository)
        {
            //_mapper = mapper;
            _TagRepository = TagRepository;
        }

        public async Task<IEnumerable<string>> Handle(GetTagStringArrayQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<string> allTags;
            if (request.Id != null)
                allTags = (await _TagRepository.ListAllAsync()).OrderBy(x => x.Name).Select(x => x.Name);
            else
                allTags = (await _TagRepository.ListAllByIdAsync(request.Id)).OrderBy(x => x.Name).Select(x => x.Name);

            return allTags;
        }
    }
}
