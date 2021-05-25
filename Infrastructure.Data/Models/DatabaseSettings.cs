﻿using FeaturesAPI.Infrastructure.Data.Interface;

namespace FeaturesAPI.Infrastructure.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ClientsCollectionName { get; set; }
        public string BooksCollectionName { get; set; }
        public string CategorysCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}