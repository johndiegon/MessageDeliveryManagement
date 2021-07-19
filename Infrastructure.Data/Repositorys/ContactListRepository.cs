﻿using FeaturesAPI.Infrastructure.Data.Interface;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositorys
{
    public class ContactListRepository : IContactListRepository
    {
        private readonly IMongoCollection<ContactListEntity> _contacts;

        public ContactListRepository(IDatabaseSettings settings)
        {
            var contactList = new MongoClient(settings.ConnectionString);
            var database = contactList.GetDatabase(settings.DatabaseName);

            _contacts = database.GetCollection<ContactListEntity>(settings.ContactListCollectionName);
        }

        public List<ContactListEntity> Get() =>
            _contacts.Find(contactList => true).ToList();

        public ContactListEntity Get(string id) =>
            _contacts.Find<ContactListEntity>(contactList => contactList.Id == id).FirstOrDefault();

        public ContactListEntity Create(ContactListEntity contactList)
        {
            _contacts.InsertOne(contactList);
            return contactList;
        }

        public ContactListEntity Update(ContactListEntity contactListIn)
        {
            _contacts.ReplaceOne(contactList => contactList.Id == contactListIn.Id, contactListIn);
            return contactListIn;
        }

        public void Delete(string id) =>
            _contacts.DeleteOne(contactList => contactList.Id == id);

        public List<ContactListEntity> GetByClientId(string idClient) =>
          _contacts.Find<ContactListEntity>(contactList => contactList.IdClient == idClient).ToList();

    }
}