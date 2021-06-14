using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Repo
{
    public class LinkRepo
    {
        private readonly DataContext _context;
        public LinkRepo(DataContext context)
        {
            _context = context;
        }
    }
}
