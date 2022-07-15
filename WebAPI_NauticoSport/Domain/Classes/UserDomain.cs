﻿using CrossCuttingConcerns.DTOs;
using CrossCuttingConcerns.Models;
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

        public GetFeaturesByUserOut getFeaturesByUser(GetFeaturesByUserIn input)
        {

            

            return new List<Feature>();
        }
    }
}