﻿using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Infrasctuture.Service.Interfaces
{
    public interface IBlobStorage
    {
        Task<string> UploadFile(IFormFile file);
    }
}