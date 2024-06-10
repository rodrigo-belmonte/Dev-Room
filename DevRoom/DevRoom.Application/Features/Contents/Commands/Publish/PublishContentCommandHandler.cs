using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DevRoom.Application.Contracts.Persistence;
using DevRoom.Application.Enums;
using DevRoom.Application.Responses;
using DevRoom.Domain.Entities;
using MediatR;

namespace DevRoom.Application.Features.Contents.Commands.Publish
{
    public class PublishContentCommandHandler : IRequestHandler<PublishContentCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Content> _contentRepository;

        public PublishContentCommandHandler(IMapper mapper, IAsyncRepository<Content> contentRepository)
        {
            _mapper = mapper;
            _contentRepository = contentRepository;
        }
        public async Task<BaseResponse> Handle(PublishContentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            try
            {
                var ContentToPublish = await _contentRepository.GetByIdAsync(request.Id);

                request.PublishedBy = "Rodrigo Belmonte de Oliveira";
                request.PublishedDate = System.DateTime.Now;
                request.Status = (int)Status.Published;

                _mapper.Map(request, ContentToPublish, typeof(PublishContentCommand), typeof(Content));

                await _contentRepository.UpdateAsync(ContentToPublish);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>{ex.Message};
            }

            return response;
        }
    }
}