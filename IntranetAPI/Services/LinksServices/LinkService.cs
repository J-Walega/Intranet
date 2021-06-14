using IntranetAPI.Entities;
using IntranetAPI.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Services.LinksServices
{
    public class LinkService : ILinkService
    {
        private readonly ILinkRepo _repo;

        public LinkService(ILinkRepo repo)
        {
            _repo = repo;
        }
        public async Task<bool> SaveLink(Link link)
        {
            await _repo.SaveLinkAsync(link);
            return true;
        }
    }
}
