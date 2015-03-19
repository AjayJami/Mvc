﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Builder;
using Microsoft.Framework.OptionsModel;

namespace FiltersWebSite
{
    public class AuthorizeBasicMiddleware : AuthenticationMiddleware<BasicOptions>
    {
        public AuthorizeBasicMiddleware(
            RequestDelegate next, 
            IOptions<BasicOptions> options,
            string authScheme) : 
                base(next, options, 
                    new ConfigureOptions<BasicOptions>(o => o.AuthenticationScheme = authScheme) { Name = authScheme })
        {
        }

        protected override AuthenticationHandler<BasicOptions> CreateHandler()
        {
            return new BasicAuthenticationHandler();
        }
    }
}