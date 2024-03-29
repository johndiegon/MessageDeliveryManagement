﻿using AutoMapper;
using Domain.Models;
using Infrastructure.Data.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.User.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, CommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public ConfirmEmailCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
        }

        public async Task<CommandResponse> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Recupera o usuário
                var user = _userRepository.GetByLogin(request.Email);

                //Verifica se o usuário existe
                if (user == null)
                    return GetResponseErro("Usuário inválido.");

                user.IsConfirmedEmail = true;

                _userRepository.Update(user);

                // Retorna os dados
                return await System.Threading.Tasks.Task.FromResult(new CommandResponse { Data = new Data { Message = "Email confirmed", Status = Status.Sucessed } });

            }
            catch (Exception ex)
            {
                var message = string.Concat("Ocorreru um erro interno: ", ex.Message);
                return await System.Threading.Tasks.Task.FromResult(GetResponseErro(message));
            }
        }

        private CommandResponse GetResponseErro(string Message)
        {
            return new CommandResponse
            {
                Data = new Data
                {
                    Message = Message,
                    Status = Status.Error
                }
            };
        }
    }
}
