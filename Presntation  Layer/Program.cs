using Business_Logic_Layer;
using Business_Logic_Layer.InterFaces;
using Business_Logic_Layer.Repositories;
using Data_Access_Layer.DbContexts;
using Microsoft.EntityFrameworkCore;
using Presntation__Layer.Mapping;

namespace Presntation__Layer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddScoped<IDepartmentRepository , DepartmentRepository>();  Will Create Auto In IUnitOfWork 
            //builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();       Will Create Auto In IUnitOfWork 
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(M=> M.AddProfile(new EmployeeProfile()));
            builder.Services.AddAutoMapper(M=> M.AddProfile(new DepartmentProfile()));
            builder.Services.AddDbContext<CompanyDbcontext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            /// builder.Services.AddScoped();    Create Object Life Time per request - Unreachable Object after request
            /// builder.Services.AddTransient(); Create Object Life Time per Operation - Unreachable Object after Operation
            /// builder.Services.AddSingleton(); Create Object Life Time per Application - Object will be alive till application is running



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
