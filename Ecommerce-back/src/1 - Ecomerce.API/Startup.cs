using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ecomerce.API.Token;
using Ecomerce.API.ViewModels;
using Ecomerce.Domain.Entities;
using Ecomerce.Infra.Context;
using Ecomerce.Infra.Interface;
using Ecomerce.Infra.Repositories;
using Ecomerce.Services.DTO;
using Ecomerce.Services.Interfaces;
using Ecomerce.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Ecomerce.API
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

            #region Jwt
                var secretKey = Configuration["Jwt:Key"];

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion

            #region Configurando AutoMapper
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Usuario, UsuarioDTO>().ReverseMap();
                cfg.CreateMap<CriandoUsuarioViewModel, UsuarioDTO>().ReverseMap();
                cfg.CreateMap<UpdateUsuarioViewModel, UsuarioDTO>().ReverseMap();

                cfg.CreateMap<Compra, CompraDTO>().ReverseMap();
                cfg.CreateMap<CriandoCompraViewModel,CompraDTO>().ReverseMap();

                cfg.CreateMap<Produto, ProdutoDTO>().ReverseMap();
                cfg.CreateMap<CriandoProdutoViewModel,ProdutoDTO>().ReverseMap();
                cfg.CreateMap<UpdateProdutoViewModel, ProdutoDTO>().ReverseMap();

                cfg.CreateMap<Companhia, CompanhiaDTO>().ReverseMap();
                cfg.CreateMap<CriandoCompanhiaViewModel,CompanhiaDTO>().ReverseMap();
                cfg.CreateMap<UpdateCompanhiaViewModel,CompanhiaDTO>().ReverseMap();

            });
            services.AddSingleton(autoMapperConfig.CreateMapper());

            #endregion

            #region Injeção de Dependência
             services.AddSingleton(d => Configuration);
            services.AddDbContext<EcomerceContext>(options => options.UseNpgsql(Configuration["ConnectionStrings:ECOMERCE"]), ServiceLifetime.Transient);
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<ICompraService, CompraService>();
            services.AddScoped<ICompraRepository,CompraRepository>();

            services.AddScoped<IProdutoService,ProdutoService>();
            services.AddScoped<IProdutoRepository,ProdutoRepository>();

            services.AddScoped<ICompanhiaService,CompanhiaService>();
            services.AddScoped<ICompanhiaRepository,CompanhiaRepository>();

            services.AddScoped<ITokenGenerator,TokenGenerator>();
            #endregion

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Ecomerce API",
                    Version = "v1",
                    Description = "API construída para o curso DFS.",
                    Contact = new OpenApiContact
                    {
                        Name = "Lucas Mota",
                        Email = "lucaslmota0431@gmail.com",
                        Url = new Uri("https://github.com/lucaslmota")
                    },
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Por favor utilize Bearer <TOKEN>",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
                });
            });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecomerce.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
