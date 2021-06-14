using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Contracts.V1.Requests.Links
{
    public class AddLinkRequest
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string Url { get; set; }
    }
}
