using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Contracts.V1.Requests.Phone
{
    public class AddPhoneRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Number { get; set; }
    }
}
