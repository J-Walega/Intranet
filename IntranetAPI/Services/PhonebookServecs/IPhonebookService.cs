﻿using IntranetAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Services.PhonebookServecs
{
    public interface IPhonebookService
    {
        Task<List<Phone>> GetPhones();
    }
}
