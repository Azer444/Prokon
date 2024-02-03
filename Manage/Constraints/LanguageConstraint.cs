using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Constraints
{
    public class LanguageConstraint : IRouteConstraint
    {
        private List<string> languages = new List<string> { "en" };
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return languages.Contains(values[routeKey]);
        }
    }
}
