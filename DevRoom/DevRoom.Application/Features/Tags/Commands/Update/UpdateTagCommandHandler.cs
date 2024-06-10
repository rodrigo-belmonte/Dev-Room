namespace DevRoom.Application.Features.Tags.Commands.Update
{
    using AutoMapper;
    using DevRoom.Application.Contracts.Persistence;
    using DevRoom.Application.Enums;
    using DevRoom.Application.Responses;
    using DevRoom.Domain.Entities;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;

        public UpdateTagCommandHandler(IMapper mapper, ITagRepository tagRepository)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
        }

        public async Task<BaseResponse> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateTagCommandResponse();
            try
            {
                request.LastModifiedBy = "Rodrigo Belmonte de Oliveira";
                request.LastModifiedDate = System.DateTime.Now;
                request.Status = (int)Status.Modified;

                var tagToUpdate = _mapper.Map<Tag>(request);
                await _tagRepository.UpdateAsync(tagToUpdate);
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>{
                    ex.Message
                };
                return response;
            }
        }
    }
}