﻿using Infrastructure.Data.Entities;
using System.Collections.Generic;

namespace Infrastructure.Data.Interfaces
{
    public interface IContactListRepository : IRepository<ContactListEntity>
    {
        List<ContactListEntity> GetByClientId(string id);
    }
}