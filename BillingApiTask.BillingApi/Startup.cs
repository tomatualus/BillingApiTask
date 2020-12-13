using BillingApiTask.Models.Configurations;
using BillingApiTask.Services;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BillingApiTask.BillingApi
{
    /// <summary>
    /// Web application start up configuration instance.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instace of <see cref="Startup"/>.
        /// </summary>
        /// <param name="configuration">The App configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureConfigurations(services);

            services.AddControllers();
            services.AddTransient<IBillingService, BillingService>();
            services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
            services.AddTransient<IPayPalClient, PayPalClient>();
            services.AddTransient<IStripeClient, StripeClient>();

            
        }

        public void ConfigureConfigurations(IServiceCollection services)
        {
            services.Configure<PaypalClientConfig>(this.Configuration.GetSection(nameof(PaypalClientConfig)));
            services.Configure<StripeClientConfig>(this.Configuration.GetSection(nameof(StripeClientConfig)));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
