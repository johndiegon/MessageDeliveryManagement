﻿using Domain.Models;
using Domain.Validators;
using MediatR;

namespace Domain.Commands.Chat
{
    public class PostMessageChat : Validate, IRequest<CommandResponse>
    {
        public MessageOnChat Message { get; set; }
        public string IdUser { get; set; }
    }
}
