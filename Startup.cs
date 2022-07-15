using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewApp.Servicios;
using NewApp.Model;
using Microsoft.EntityFrameworkCore;
using NewApp;

namespace NewApp
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
            
            services.AddRazorPages(
                options => {
                    options.Conventions.AuthorizeFolder("/Paciente");
                    options.Conventions.AuthorizeFolder("/Medico");
                    options.Conventions.AuthorizeFolder("/Departamento");
                    options.Conventions.AllowAnonymousToPage("/Departamento/Index");
                }
            );
            
            services.AddScoped<IDepartamentoService,DepartamentoService>();
            services.AddScoped<IPaciente,PacienteService>();
            services.AddScoped<IMedico,MedicoService>();
            services.AddMvc().AddRazorPagesOptions(o=> o.Conventions.AddPageRoute("/index","Lista-Pacientes"));
            services.AddMvc().AddRazorPagesOptions(o=> o.Conventions.AddPageRoute("/index","Lista-Medicos"));
            services.AddDbContext<HospitalDbContext>(o=> o.UseSqlServer(Configuration.GetConnectionString("HospitalConex")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
