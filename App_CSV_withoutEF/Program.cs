using App_CSV_withoutEF.BLL.Repository;
using App_CSV_withoutEF.BLL.Services;
using AutoMapper;

namespace App_CSV_withoutEF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddRazorPages(opt => opt.RootDirectory = "/MyPages");

            builder.Services.AddScoped<ICommonRepo, CommonRepo>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IOrganizationRepo, OrganizationRepo>();

            builder.Services.AddAutoMapper((v) =>
            {
                v.AddProfile(new MappingProfile());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
               
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapRazorPages();

            app.Run();
        }
    }
}
