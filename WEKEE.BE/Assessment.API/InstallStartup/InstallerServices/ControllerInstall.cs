﻿using Assessment.API.FilterAttributeCore.ActionFilters;
using Assessment.API.FilterAttributeCore.ExceptionFilter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Assessment.API.FilterAttributeCore.AuthorizationFilter;
using Microsoft.AspNetCore.Builder;
using System.Net;

namespace Assessment.API.InstallStartup.InstallerServices
{
    public class ControllerInstall : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ForwardedHeadersOptions>(op=> {

                op.KnownProxies.Add(IPAddress.Parse("You"));
            });
            services.AddControllers(op=>
            {
                op.Filters.Add(new ValidationFilterAttribute());
                //op.Filters.Add(new ProcessAuthorizationFilter());
                op.Filters.Add(new ExcutionTimeFilterAttribute());
                op.Filters.Add(new ProcessExceptionFilterAttribute());
            });
        }
    }
}