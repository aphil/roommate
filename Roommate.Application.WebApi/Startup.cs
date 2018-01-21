using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Roommate.Application.Appointments;
using Roommate.Application.Shared.Appointments;
using Roommate.Application.Shared.Configurations;
using Roommate.Repository.Appointments;
using Roommate.Repository.Business;
using Roommate.Repository.Outlook;

namespace Roommate.Application.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IAppointmentService, AppointmentService>();
            var appointmentProviderType = Configuration.GetValue<AppointmentProviderTypeEnum>(ConfigurationKeys.AppointmentProviderType);
            if (appointmentProviderType == AppointmentProviderTypeEnum.None)
            {
                throw new MissingConfigurationException(ConfigurationKeys.AppointmentProviderType);
            }

            switch (appointmentProviderType)
            {
                case AppointmentProviderTypeEnum.Exchange:
                    services.AddScoped<IAppointmentRepository, ExchangeAppointmentRepository>();
                    services.AddScoped<IExchangeServiceInitializer, ExchangeServiceInitializer>((provider) =>
                        new ExchangeServiceInitializer(Configuration.GetValue<string>(ConfigurationKeys.ExchangeUsername),
                                                        Configuration.GetValue<string>(ConfigurationKeys.ExchangePassword),
                                                        Configuration.GetValue<string>(ConfigurationKeys.ExchangeDomain),
                                                        Configuration.GetValue<string>(ConfigurationKeys.ExchangeUrl),
                                                        Configuration.GetValue<string>(ConfigurationKeys.RoomEmailAddress))
                        );
                    break;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
