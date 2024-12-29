using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Data.Contexts;
using School.Data.Entities.IdentityEntities;
using School.Repository.Interfaces;
using School.Repository.Repository;
using School.Services.Mapping.Profiles;
using School.Services.Services.Students;
using School.Services.Services.Subjects;
using School.Services.Services.Token;
using School.Services.Services.User;
using School.Web.Helper.HandleResponse;

namespace School.Web.Extensions
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<SchoolDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<SchoolDbContext>()
                .AddDefaultTokenProviders();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenService,TokenService>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapper(typeof(SubjectProfile));
            services.AddAutoMapper(typeof(StudentProfile));


            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                                .Where(model => model.Value?.Errors.Count > 0)
                                .SelectMany(model => model.Value?.Errors)
                                .Select(error => error.ErrorMessage)
                                .ToList();

                    var errorResponse = new ValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });
            return services;
        }
    }
}
