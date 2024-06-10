using AutoMapper;
using DevRoom.Application.Contracts.Persistence;
using DevRoom.Application.Enums;
using DevRoom.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevRoom.Application.Features.Contents.Queries.GetContentsList
{
    public class GetContentsListQueryHandler : IRequestHandler<GetContentsListQuery, IEnumerable<ContentListVm>>
    {
        private readonly IAsyncRepository<Content> _ContentRepository;
        private readonly IMapper _mapper;

        public GetContentsListQueryHandler(
            IMapper mapper,
            IAsyncRepository<Content> ContentRepository
            )
        {
            _mapper = mapper;
            _ContentRepository = ContentRepository;
        }

        public async Task<IEnumerable<ContentListVm>> Handle(GetContentsListQuery request, CancellationToken cancellationToken)
        {
            var allContents = (await _ContentRepository.ListAllAsync())
            .Where(x => x.Status != (int)Status.Deleted);

            var contents = _mapper.Map<List<ContentListVm>>(allContents).Select(c =>
            {
                c.StatusName = ((Status)c.Status).ToString();

                return c;
            });

            return contents;
        }
    }
}
