
using Microsoft.EntityFrameworkCore;
using School.Data.Contexts;
using School.Web.Extensions;
using School.Web.Helper;
using School.Web.Helper.MiddleWares;

namespace School.Web
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddApplicationService(builder.Configuration);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerDocumentation();

            builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http:localhost:4200", "http://localhost:36496");

            }));

            var app = builder.Build();
            await ApplySeeding.ApplySeedingAsync(app);


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionMiddleWare>();
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
