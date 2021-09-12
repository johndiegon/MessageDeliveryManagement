﻿using AutoMapper;
using Domain.Models;
using Infrastructure.Data.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.List.GetResume
{

    public class GetResumeListCommandHandler : IRequestHandler<GetResumeListCommand, GetResumeListCommandResponse>
    {
        private readonly IResumeContactListRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetResumeListCommandHandler(IResumeContactListRepository repository
                                     , IMapper mapper
                                     , IMediator mediator
                                     )
        {
            _repository = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<GetResumeListCommandResponse> Handle(GetResumeListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = new GetResumeListCommandResponse();
                if (!request.IsValid())
                {
                    response = GetResponseErro("The request is invalid.");
                    response.Notification = request.Notifications();
                }
                else
                {
                    var repost = _repository.Get(request.IdClient);

                    var resume = _mapper.Map<ResumeContactList>(repost);

                    response = new GetResumeListCommandResponse
                    {
                        Resume = resume,
                        Data = new Data
                        {
                            Status = Status.Sucessed
                        }
                    };
                }

                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(GetResponseErro(ex.Message));
            }
        }

        private GetResumeListCommandResponse GetResponseErro(string Message)
        {
            return new GetResumeListCommandResponse
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