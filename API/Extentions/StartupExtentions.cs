using System.Text;
using API.Services;
using Application.Interfaces;
using Application.Photos;
using Application.Services;
using Domain.Interfaces;
using Domain.Models;
using FluentValidation.AspNetCore;
using Infrastructure.Photos;
using Infrastructure.Security;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using Persistence.Repositories;
using Persistence.Wrappers;

namespace API.Extentions
{
    public static class StartupExtentions
    {
        public static IServiceCollection SetupCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IActivitiesRepository, ActivitiesRepository>();
            services.AddScoped<IActivityAttendeesRepository, ActivityAttendeesRepository>();
            services.AddScoped<IPhotosRepository, PhotosRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IActivitiesService, ActivitiesService>();
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();

            services.AddAutoMapper(typeof(Application.Core.MappingProfile).Assembly);
            services.AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<Application.Validation.ActivityValidation>();
            });
            services.AddMediatR(typeof(Add).Assembly);

            return services;
        }

        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));

            services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<DataContext>()
            .AddSignInManager<SignInManager<User>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("IsActivityHost", policy => policy.Requirements.Add(new IsHostRequirement()));
                opt.AddPolicy("IsAccountOwner", policy => policy.Requirements.Add(new IsAccountOwnerRequirement()));
            });
            services.AddTransient<IAuthorizationHandler, IsHostRequirementHandler>();
            services.AddTransient<IAuthorizationHandler, IsAccountOwnerRequirementHandler>();
            services.AddScoped<TokenService>();

            return services;
        }

        public static IServiceCollection SetupCustomConfigurations(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<CloudinarySettings>(config.GetSection("Cloudinary"));
            return services;
        }
    }
}