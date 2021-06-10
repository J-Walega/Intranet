using System;
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
            public const string UploadFile = Base + "/links";
        }
    }
}
