using CodebitsBlog.Areas.Admin.Models;
using CodebitsBlog.Areas.Admin.Services;
using CodebitsBlog.Data;
using CodebitsBlog.Helpers;
using CodebitsBlog.Repositories;
using CodebitsBlog.Repositories.Interface;
using CodebitsBlog.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CodebitsBlog
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			                options.UseSqlServer(connectionString));

			builder.Services.AddIdentity<ApplicationUser, IdentityRole<string>>(options =>
			{
                                options.Password.RequireDigit = true;
                                options.Password.RequireLowercase = true;
                                options.Password.RequireUppercase = true;
                                options.Password.RequireNonAlphanumeric = true;
                                options.Password.RequiredLength = 5;
                                options.SignIn.RequireConfirmedAccount = false;
                                options.SignIn.RequireConfirmedEmail = false;
                                options.SignIn.RequireConfirmedPhoneNumber = false;
                                options.User.RequireUniqueEmail = true;
								options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
								options.Lockout.MaxFailedAccessAttempts = 5;
								options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                            })
                            .AddEntityFrameworkStores<ApplicationDbContext>()
                            .AddDefaultTokenProviders();

			builder.Services.ConfigureApplicationCookie(options =>
			{
                options.LoginPath = "/admin/dashboard/login";
                options.LogoutPath = "/admin/dashboard/login";
                options.AccessDeniedPath = "/admin/dashboard/login";
            });


			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<IPostRepository, PostRepository>();
			builder.Services.AddScoped<IpostService, PostService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.AddSingleton<UtilityService>();

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

			app.UseAuthentication();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "admin",
				pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");			

			app.Run();
		}
	}
}
