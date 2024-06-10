using AutoMapper;
using DevRoom.Application.Contracts.Persistence;
using DevRoom.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DevRoom.Application.Features.Users.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public LoginCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var loginCommandResponse = new LoginCommandResponse();

            try
            {
                var user = await _userRepository.LoginAsync(request.User, request.Password);
                if (user == null)
                    throw new NotFoundException(nameof(user), request.User);

                loginCommandResponse.User = _mapper.Map<LoginDto>(user);
            }
            catch (Exception ex)
            {
                loginCommandResponse.Success = false;
                loginCommandResponse.ValidationErrors = new List<string>();
                loginCommandResponse.ValidationErrors.Add(ex.Message);
            }

            return loginCommandResponse;
        }
    }
}