using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Repositorio.Contexto;
using QuickBuy.Repositorio.Repositorios;

namespace QuickBuy.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration) { 

            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("config.json",optional:false, reloadOnChange:true);
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*permite acessar o contexto da requisiçã.
              Então toda vez que o sistema foi acessado e tiver uma requesião da WEB API
              vai ser aberto uma sessão com servidor e também um contexto da requisição.
              
             Logo toda requisição vai ter um contexto.*/
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                /*Configurando o ASP.NET core para quando retornar estruturas em JSON para ele
                 ignorar referências em Loop*/
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            var connectionString = Configuration.GetConnectionString("QuickBuyDB");

            /* permite carregar as entidades de forma automatica no banco, ou seja em tempo de execução */
            services.AddDbContext<QuickBuyContexto>(option =>
                                                              option.UseLazyLoadingProxies()
                                                              .UseMySql(connectionString,
                                                                                    m => m.MigrationsAssembly("QuickBuy.Repositorio"))); ; ; ;

            //  injeções de depedencias igual no angular onde você vai no modulo e declara aquele tipo de injeção de dependecia.
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();


            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                   // spa.UseAngularCliServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200/");
                }
            });
        }
    }
}
