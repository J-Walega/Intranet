using IntranetAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Repo.Interfaces
{
    public interface ILinkRepo
    {
        Task<bool> SaveLinkAsync(Link link);
    }
}
