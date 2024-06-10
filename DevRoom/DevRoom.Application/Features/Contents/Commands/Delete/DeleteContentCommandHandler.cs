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

namespace DevRoom.Application.Features.Contents.Commands.Delete
{
    public class DeleteContentCommandHandler : IRequestHandler<DeleteContentCommand, BaseResponse>
    {
        private readonly IAsyncRepository<Content> _ContentRepository;
        private readonly IMapper _mapper;

        public DeleteContentCommandHandler(IMapper mapper, IAsyncRepository<Content> ContentRepository)
        {
            _mapper = mapper;
            _ContentRepository = ContentRepository;
        }

        public async Task<BaseResponse> Handle(DeleteContentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            try
            {
                var ContentToDelete = await _ContentRepository.GetByIdAsync(request.ContentId);

                if (ContentToDelete == null)
                {
                    throw new NotFoundException(nameof(Content), request.ContentId);
                }

                ContentToDelete.Status = (int)Status.Deleted;
                ContentToDelete.DeletedDate = System.DateTime.Now;
                ContentToDelete.DeletedBy = "Rodrigo Belmonte de Oliveira";
                await _ContentRepository.UpdateAsync(ContentToDelete);
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
