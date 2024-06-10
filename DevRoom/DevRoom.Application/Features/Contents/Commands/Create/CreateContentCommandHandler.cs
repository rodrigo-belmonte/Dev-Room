using AutoMapper;
using DevRoom.Application.Contracts.Persistence;
using DevRoom.Application.Enums;
using DevRoom.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DevRoom.Application.Features.Contents.Commands.Create
{
    public class CreateContentCommandHandler : IRequestHandler<CreateContentCommand, CreateContentCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Content> _contentRepository;

        public CreateContentCommandHandler(IMapper mapper, IAsyncRepository<Content> contentRepository)
        {
            _mapper = mapper;
            _contentRepository = contentRepository;
        }
        public async Task<CreateContentCommandResponse> Handle(CreateContentCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateContentCommandResponse();
            var validator = new CreateContentCommandValidator(_contentRepository);
            var validationResult = await validator.ValidateAsync(request);
            var content = _mapper.Map<Content>(request);
            
            try
            {
                if (validationResult.Errors.Count > 0)
                    throw new Exceptions.ValidationException(validationResult);
                    
                content.CreatedDate = DateTime.Now;
                content.CreatedBy = "Rodrigo Belmonte de Oliveira";
                content.Status = (int)Status.Draft;

                content = await _contentRepository.AddAsync(content);
                response.Id = content.Id;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>{
                    ex.Message
                };
            }
            return response;
        }
    }
}
