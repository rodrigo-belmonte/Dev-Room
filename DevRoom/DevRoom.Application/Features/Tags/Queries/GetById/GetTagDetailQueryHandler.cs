using AutoMapper;
using DevRoom.Application.Contracts.Persistence;
using DevRoom.Application.Exceptions;
using DevRoom.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevRoom.Application.Features.Tags.Queries.GetById
{
    public class GetTagDetailQueryHandler : IRequestHandler<GetTagDetailQuery, TagDetailVm>
    {
        private readonly IAsyncRepository<Tag> _TagRepository;
        private readonly IMapper _mapper;

        public GetTagDetailQueryHandler(IMapper mapper, IAsyncRepository<Tag> TagRepository)
        {
            _mapper = mapper;
            _TagRepository = TagRepository;
        }

        public async Task<TagDetailVm> Handle(GetTagDetailQuery request, CancellationToken cancellationToken)
        {
            
            var tag = await _TagRepository.GetByIdAsync(request.Id);
            var TagDetailDto = _mapper.Map<TagDetailVm>(tag);


            if (tag == null)
            {
                throw new NotFoundException(nameof(tag), request.Id);
            }

            return TagDetailDto;

        }
    }
}
