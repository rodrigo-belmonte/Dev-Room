using AutoMapper;
using DevRoom.Application.Contracts.Persistence;
using DevRoom.Application.Exceptions;
using DevRoom.Application.Responses;
using DevRoom.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DevRoom.Application.Features.Tags.Commands.Delete
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, BaseResponse>
    {
        private readonly IAsyncRepository<Tag> _TagRepository;
        private readonly IMapper _mapper;

        public DeleteTagCommandHandler(IMapper mapper, IAsyncRepository<Tag> TagRepository)
        {
            _mapper = mapper;
            _TagRepository = TagRepository;
        }

        public async Task<BaseResponse> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            try
            {
                var TagToDelete = await _TagRepository.GetByIdAsync(request.Id);

                if (TagToDelete == null)
                {
                    throw new NotFoundException(nameof(Tag), request.Id);
                }

                await _TagRepository.DeleteAsync(TagToDelete);

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
