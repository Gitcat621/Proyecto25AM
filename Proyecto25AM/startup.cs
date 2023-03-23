using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;
using Proyecto25AM.Services.Services;

namespace Proyecto25AM
{
    public class startup
    {
        private readonly string PolicyCors = "PolicyCors";
        public startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Add services to the container.
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //PolicyCors
            services.AddCors(options =>
            {
                options.AddPolicy(name: PolicyCors, 
                    builder =>
                    {
                    builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                    .AllowAnyHeader().AllowAnyMethod();
                    });
            });

            //Inyeccion de dependencias
            services.AddTransient<IUsuarioServices, UsuarioServices>();
            services.AddTransient<IClienteServices, ClienteServices>();
            services.AddTransient<IDepartamentoServices, DepartamentoServices>();
            services.AddTransient<IFacturaServices, FacturaServices>();
            services.AddTransient<IEmpleadoServices, EmpleadoServices>();
            services.AddTransient<IPuestoServices, PuestoServices>();
            services.AddTransient<IRolServices, RolServices>();

        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(PolicyCors);

            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
