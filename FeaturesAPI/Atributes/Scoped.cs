﻿using Domain.Commands.Authenticate;
using Domain.Commands.Calendar.Delete;
using Domain.Commands.Calendar.Post;
using Domain.Commands.Calendar.Put;
using Domain.Commands.Chat.Post;
using Domain.Commands.Client.Delete;
using Domain.Commands.Client.Post;
using Domain.Commands.Client.Put;
using Domain.Commands.Contact.Post;
using Domain.Commands.Contact.Put;
using Domain.Commands.Facebook.Post;
using Domain.Commands.File.Post;
using Domain.Commands.List.GetResume;
using Domain.Commands.List.SendAMessage;
using Domain.Commands.Message.Delete;
using Domain.Commands.Message.Post;
using Domain.Commands.Message.Put;
using Domain.Commands.Post.TwiilioAccess;
using Domain.Commands.Post.TwilioAccess;
using Domain.Commands.Put.TwiilioAccess;
using Domain.Commands.Put.TwilioAccess;
using Domain.Commands.SessionWhats.Post;
using Domain.Commands.User.ChangePassword;
using Domain.Commands.User.ConfirmEmail;
using Domain.Commands.User.Post;
using Domain.Commands.User.Put;
using Domain.Commands.UserHub;
using Domain.Models;
using Domain.Queries.Address;
using Domain.Queries.Calendar.Get;
using Domain.Queries.Chat.Get;
using Domain.Queries.Chat.GetLast;
using Domain.Queries.Client;
using Domain.Queries.ContactByClientId;
using Domain.Queries.Dashboard.Get;
using Domain.Queries.FileInput.Get;
using Domain.Queries.Message.Get;
using Domain.Queries.TwilioAccess.Get;
using FeaturesAPI.Services;
using Infrasctuture.Service.Interfaces;
using Infrasctuture.Service.ServicesHandlers;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Repositorys;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FeaturesAPI.Atributes
{
    public static class Scoped
    {
        public static void Add(IServiceCollection services)
        {
            //AutoMapper

            #region >> Commands
            #region >> Client
            services.AddTransient<IRequestHandler<PostClientCommand, PostClientCommandResponse>, PostClientCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteClientCommand, CommandResponse>, DeleteClientCommandHandler>();
            services.AddTransient<IRequestHandler<PutClientCommand, PutClientCommandResponse>, PutClientCommandHandler>();
            #endregion

            #region >> Address
            services.AddTransient<IRequestHandler<GetAddressByZipCode, GetAddressResponse>, GetAddressHandler>();

            #endregion

            #region >> User
            services.AddTransient<IRequestHandler<PostUserCommand, PostUserCommandResponse>, PostUserCommandHandler>();
            services.AddTransient<IRequestHandler<PutUserCommand, CommandResponse>, PutUserCommandHandler>();
            services.AddTransient<IRequestHandler<AuthenticateCommand, AuthenticateCommandResponse>, AuthenticateCommandHandler>();
            services.AddTransient<IRequestHandler<ChangePasswordCommand, CommandResponse>, ChangePasswordCommandHandler>();
            services.AddTransient<IRequestHandler<ConfirmEmailCommand, CommandResponse>, ConfirmEmailCommandHandler>();

            #endregion

            #region >> Dash

            services.AddTransient<IRequestHandler<GetDashboardQuery, GetDashboardQueryResponse>, GetDashboardQueryHandler>();
            #endregion

            #region >> File
            services.AddTransient<IRequestHandler<PostFileCommand, PostFileCommandResponse>, PostFileCommandHandler>();
            services.AddTransient<IRequestHandler<GetHistorysFileQuery, GetHistorysFileQueryResponse>, GetHistorysFileQueryHandler>();

            #endregion

            #region >> Contact
            services.AddTransient<IRequestHandler<PostContactCommand, PostContactCommandResponse>, PostContactCommandHandler>();
            services.AddTransient<IRequestHandler<PutContactCommand, CommandResponse>, PutContactCommandHandler>();
            #endregion

            #region >> List
            services.AddTransient<IRequestHandler<GetResumeListCommand, GetResumeListCommandResponse>, GetResumeListCommandHandler>();

            #endregion

            #region >> Send a Message 
            services.AddTransient<IRequestHandler<MessageToListCommand, CommandResponse>, MessageToListCommandHandler>();

            #endregion

            #region >> Facebook WebHook

            services.AddTransient<IRequestHandler<PostFacebookMessageCommand, CommandResponse>, PostFacebookMessageHandler>();
            #endregion


            #region >> Credentials Twilio

            services.AddTransient<IRequestHandler<PostTwilioAccess, CommandResponse>, PostTwilioAccessHandler>();
            services.AddTransient<IRequestHandler<PutTwilioAccess, CommandResponse>, PutTwilioAccessHandler>();
            services.AddTransient<IRequestHandler<GetTwilioCredentials, GetTwilioCredentialsResponse>, GetTwilioCredentialsHandler>();

            #endregion


            #endregion

            #region >> Query

            #region >> Client
            services.AddTransient<IRequestHandler<GetClientQuery, GetClientQueryResponse>, GetClientQueryHandler>();

            #endregion

            #region >> Contact
            services.AddTransient<IRequestHandler<GetContactsQuery, GetContactsQueryResponse>, GetContactsQueryHandler>();

            #endregion

            #endregion

            #region >> Chat
            services.AddTransient<IRequestHandler<PostMessageChat, CommandResponse>, PostMessageChatHandler>();
            services.AddTransient<IRequestHandler<GetChatMessage, GetChatMessageResponse>, GetChatMessageHandler>();
            services.AddTransient<IRequestHandler<GetLastMessages, GetLastMessagesResponse>, GetLastMessagesHandler>();
            services.AddTransient<IRequestHandler<PostUserHubConectionCommand, CommandResponse>, PostUserHubConectionHandler>();

            #endregion

            #region >> Session 

            services.AddTransient<IRequestHandler<GetTwilioCredentials, GetTwilioCredentialsResponse>, GetTwilioCredentialsHandler>();
            services.AddTransient<IRequestHandler<PostSessionWhatsCommand, CommandResponse>, PostSessionWhatsHandler>();

            #endregion

            #region >> Session 

            services.AddTransient<IRequestHandler<DeleteMessageCommand, CommandResponse>, DeleteMessageHandler>();
            services.AddTransient<IRequestHandler<PutMessageCommand, CommandResponse>, PutMessageHandler>();
            services.AddTransient<IRequestHandler<PostMessageCommand, CommandResponse>, PostMessageHandler>();
            services.AddTransient<IRequestHandler<GetMessageQuery, GetMessageResponse>, GetMessageHandler>();
            services.AddTransient<IRequestHandler<PostCalendar, PostCalendarResponse>, PostCalendarHandler>();
            services.AddTransient<IRequestHandler<PutCalendar, CommandResponse>, PutCalendarHandler>();
            services.AddTransient<IRequestHandler<DeleteCalendar, CommandResponse>, DeleteCalendarHandler>();
            services.AddTransient<IRequestHandler<GetCalendar, GetCalendarResponse>, GetCalendarHandler>();

            #endregion

            services.AddScoped(typeof(IViaCepService), typeof(ViaCepService));

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<ILastMessageRepository, LastMessageRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IResumeContactListRepository, ResumeContactListRepository>();
            services.AddScoped<ISessionWhatsAppRepository, SessionWhatsAppRepository>();
            services.AddScoped<IMessagesDefaultRepository, MessagesDefaultRepository>();
            services.AddScoped<ITwillioAccessRepository, TwillioAccessRepository>();
            services.AddScoped<IFacebookMessageRepository, FacebookMessageRepository>();
            services.AddScoped<IUserHubConectionRepository, UserHubConectionRepository>();
            services.AddScoped<IReportSendersRepository, ReportSendersRepository>();
            services.AddScoped<IReportAnswerRepository, ReportAnswerRepository>();
            services.AddScoped<IReportFileRepository, ReportFileRepository>();
            services.AddScoped<IReportSendersRepository, ReportSendersRepository>();
            services.AddSingleton<ClientRepository>();
            services.AddSingleton<ContactRepository>();
            services.AddSingleton<UserRepository>();
            services.AddSingleton<ResumeContactListRepository>();
            services.AddSingleton<ChatRepository>();
            services.AddSingleton<LastMessageRepository>();
            services.AddSingleton<SessionWhatsAppRepository>();
            services.AddSingleton<MessagesDefaultRepository>();
            services.AddSingleton<TwillioAccessRepository>();
            services.AddScoped<ICalendarRepository, CalendarRepository>();
            services.AddControllersWithViews();

            services.AddScoped<IStorage, OrderStorage>();
            services.AddScoped<ITopicServiceBuss, ServiceTopic>();



        }
    }
}
