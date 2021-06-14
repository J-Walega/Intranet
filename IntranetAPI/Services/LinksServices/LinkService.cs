using IntranetAPI.Contracts.V1.Requests.Links;
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

        public async Task<List<Link>> GetLinksByCategory(string category)
        {
            return await _repo.GetLinksByCategoryAsync(category);
        }

        public async Task<bool> SaveLink(AddLinkRequest request)
        {
            Link link = new()
            {
                Category = request.Category,
                Url = request.Url,
                Description = request.Description
            };

            if(await _repo.SaveLinkAsync(link) == true)
            {
                return true;
            }
            return false;
        }
    }
}
