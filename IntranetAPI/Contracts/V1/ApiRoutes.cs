﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Contracts.V1
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;


        public static class Authorize
        {
            public const string Login = Base + "/login";
            public const string Register = Base + "/register";
        }
        public static class Links
        {
            public const string GetLinks = Base + "/links/{category}";
            public const string AddLink = Base + "/link";
        }

        public static class Files
        {
            public const string GetAll = Base + "/files";
            public const string GetByCategory = Base + "/files/{category}";
            public const string Upload = Base + "/files/upload";
            public const string Delete = Base + "/files/{id}";
        }

        public static class Phonebook
        {
            public const string Add = Base + "/phones";
            public const string GetAll = Base + "/phones";
            public const string Update = Base + "/phones/{phoneId}";
            public const string Delete = Base + "/phones/{phoneId}";
        }
    }
}
