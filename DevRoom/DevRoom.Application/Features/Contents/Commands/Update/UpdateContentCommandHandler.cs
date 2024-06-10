using AutoMapper;
using DevRoom.Application.Contracts.Persistence;
using DevRoom.Application.Enums;
using DevRoom.Application.Exceptions;
using DevRoom.Application.Responses;
using DevRoom.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DevRoom.Application.Features.Contents.Commands.Update
{
    public class UpdateContentCommandHandler : IRequestHandler<UpdateContentCommand, BaseResponse>
    {
        private readonly IAsyncRepository<Content> _ContentRepository;
        private readonly IMapper _mapper;

        public UpdateContentCommandHandler(IMapper mapper, IAsyncRepository<Content> ContentRepository)
        {
            _mapper = mapper;
            _ContentRepository = ContentRepository;
        }

        public async Task<BaseResponse> Handle(UpdateContentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            try
            {
                var ContentToUpdate = await _ContentRepository.GetByIdAsync(request.Id);

                var validator = new UpdateContentCommandValidator();
                var validationResult = await validator.ValidateAsync(request);

                if (validationResult.Errors.Count > 0)
                    throw new ValidationException(validationResult);

                request.LastModifiedBy = "Rodrigo Belmonte de Oliveira";
                request.LastModifiedDate = System.DateTime.Now;
                request.PublishedBy = null;
                request.PublishedDate = null;
                request.Status = (int)Status.Draft;

                _mapper.Map(request, ContentToUpdate, typeof(UpdateContentCommand), typeof(Content));

                await _ContentRepository.UpdateAsync(ContentToUpdate);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                response.ValidationErrors.Add(ex.Message);
            }

            return response;
        }
    }
}