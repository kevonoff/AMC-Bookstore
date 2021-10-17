using AMC.Bookstore.DataAccess.DatabaseContext;
using AMC.Bookstore.DataAccess.Repositories;
using AMC.Bookstore.DataAccess.Repositories.Interfaces;
using AMC.Bookstore.Services;
using AMC.Bookstore.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AMC.Bookstore.Web
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
            services.AddControllers();
            services.AddHttpContextAccessor();

            services.AddDbContext<BookstoreDbContext>(options => options.UseInMemoryDatabase("BookstoreDb"));

            services.AddTransient<IBookstoreRepository, BookstoreRepository>();
            services.AddTransient<IBookstoreService, BookstoreService>();
            services.AddTransient<ILinkBuilder, BookstoreLinkBuilder>();
            services.AddTransient<IHttpContextService, HttpContextService>();
            services.AddTransient<IResourceBuilder, ResourceBuilder>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UsePathBase("/bookstore");

            using var serviceScope = app.ApplicationServices
                                    .GetRequiredService<IServiceScopeFactory>()
                                    .CreateScope();

            var service = serviceScope.ServiceProvider;

            Initializer.Initialize(service);

        }
    }
}
