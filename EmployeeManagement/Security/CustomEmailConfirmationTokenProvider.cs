﻿using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EmployeeManagement.Security
{
    public class CustomEmailConfirmationTokenProvider<TUser>
        : DataProtectorTokenProvider<TUser> where TUser : class
    {
        public CustomEmailConfirmationTokenProvider(
            IDataProtectionProvider dataProtectionProvider,
            IOptions<DataProtectionTokenProviderOptions> options,
            ILogger<DataProtectorTokenProvider<TUser>> logger)
            : base(dataProtectionProvider, options, logger)
        {
        }
    }
}
