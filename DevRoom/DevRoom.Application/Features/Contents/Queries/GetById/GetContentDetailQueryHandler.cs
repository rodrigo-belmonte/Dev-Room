using AutoMapper;
using DevRoom.Application.Contracts.Persistence;
using DevRoom.Application.Exceptions;
using DevRoom.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevRoom.Application.Features.Contents.Queries.GetById
{
    public class GetContentDetailQueryHandler : IRequestHandler<GetContentDetailQuery, ContentDetailVm>
    {
        private readonly IAsyncRepository<Content> _ContentRepository;
        private readonly IMapper _mapper;

        public GetContentDetailQueryHandler(IMapper mapper, IAsyncRepository<Content> ContentRepository)
        {
            _mapper = mapper;
            _ContentRepository = ContentRepository;
        }

        public async Task<ContentDetailVm> Handle(GetContentDetailQuery request, CancellationToken cancellationToken)
        {
            var content = await _ContentRepository.GetByIdAsync(request.Id);
            if (content.Status == 4)
                throw new NotFoundException(nameof(Content), request.Id);

            var ContentDetailDto = _mapper.Map<ContentDetailVm>(content);

            return ContentDetailDto;
        }
    }
}
