using IntranetAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Services.LinksServices
{
    public interface ILinkService
    {
        Task<bool> SaveLink(Link link);
    }
}
