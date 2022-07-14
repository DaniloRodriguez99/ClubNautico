using System;
using System.Collections.Generic;
using System.Security.Claims;


namespace Domain.Classes
{
    internal class UserDomain
    {
        #region singleton
        private static UserDomain _instance = new UserDomain();

        private UserDomain() { }

        public static UserDomain Instance()
        {
            return _instance;
        }
        #endregion

        public IActionResult getFeaturesByUser()
{

            var identity = HttpContext.User.Identity as ClaimsIdentity;

            return Ok(identity);
        }
    }
}
