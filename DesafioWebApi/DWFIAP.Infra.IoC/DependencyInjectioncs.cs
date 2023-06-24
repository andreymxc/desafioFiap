using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DWFIAP.Application.Mappings;
using DWFIAP.Application.Services;
using DWFIAP.Application.Services.Interfaces;
using DWFIAP.Domain.Repositories;
using DWFIAP.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DWFIAP.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DWFIAP.Data.Configuration.DwfiapContext>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<IAlunoTurmaRepository, AlunoTurmaRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDTOMapping));
            services.AddAutoMapper(typeof(DTOToDomainMapping));
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<ITurmaService, TurmaService>();
            services.AddScoped<IAlunoTurmaService, AlunoTurmaService>();
            return services;
        }
    }
}
