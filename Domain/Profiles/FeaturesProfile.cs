﻿using AutoMapper;
using Domain.Models;
using Domain.Models.Enums;
using FeaturesAPI.Domain.Models;
using FeaturesAPI.Infrastructure.Data.Entities;
using FeaturesAPI.Infrastructure.Models;
using Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Profiles
{
    public class FeaturesProfile : Profile
    {
        public FeaturesProfile()
        {
            #region >> Mapping Chat
            CreateMap<Chat, ChatEntity>();
            CreateMap<MessageOnChat, MessageOnChatEntity>();

            CreateMap<ListLastMessages, ListLastMessageEntity>();
            CreateMap<LastMessage, LastMessageEntity>();

            CreateMap<ChatEntity, Chat>();
            CreateMap<MessageOnChatEntity, MessageOnChat>();

            CreateMap<ListLastMessageEntity, ListLastMessages>();
            CreateMap<LastMessageEntity, LastMessage>();

            CreateMap<MessageDefault, MessagesDefaultEntity>();
            CreateMap<MessagesDefaultEntity, MessageDefault>();

            #endregion

            #region >> Mapping Command

            CreateMap<AddressData, AddressEntity>();
            CreateMap<People, ClientEntity>();

            #endregion

            #region >> Mapping Response
            CreateMap<AddressEntity, AddressData>();
            CreateMap<ClientEntity, People>();
            #endregion


            #region >> Mapping Command

            CreateMap<Models.ContactList, ContactListEntity>();
            CreateMap<Models.TypeList, TypeListEntity>();

            #endregion

            #region >> Mapping Response

            CreateMap<ContactListEntity, Models.ContactList>();
            CreateMap<TypeListEntity, Models.TypeList>();

            #endregion

            #region >> Mapping Command

            CreateMap<Models.Contact, ContactEntity>();
            CreateMap<Order, OrderEntity>();
            CreateMap<ContactStatus, ContactStatusEntity>();

            #endregion

            #region >> Mapping Response
            CreateMap<ContactEntity, Models.Contact>();
            CreateMap<OrderEntity, Order>();
            CreateMap<ContactStatusEntity, ContactStatus>();
            #endregion

            CreateMap<DataDashboard, DataDashboardEntity>()
             .ForMember(m => m.Id, opt => opt.Ignore());

            CreateMap<DataDashboardEntity, DataDashboard>();

            CreateMap<GeneralDataEntity, GeneralData>();
            CreateMap<GeneralData, GeneralDataEntity>();

            CreateMap<ResumeContactListEntity, ResumeContactList>();

            CreateMap<ResumeContactList, ResumeContactListEntity>();


            CreateMap<SessionWhatsApp, SessionWhatsAppEntity>();
            CreateMap<SessionWhatsAppEntity, SessionWhatsApp>();

            #region >> Mapping Command

            CreateMap<UserModel, UserEntity>();
            CreateMap<UserEntity, UserModel>();
            #endregion
        }
    }
}