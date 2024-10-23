using Event_Registration_System.Data;
using Microsoft.EntityFrameworkCore;
using MVCAuth.Services;

namespace Event_Registration_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
             




            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            string ConnectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<EventContext>(op => op.UseSqlServer(ConnectionStringVar));

            builder.Services.AddScoped<MailjetService>();


            builder.Services.AddScoped(provider =>
            {
                var
                configuration = provider.GetRequiredService<IConfiguration>();
                string
                apiKey = configuration[
                "Mailjet:ApiKey"
                ];
                string
                secretKey = configuration[
                "Mailjet:SecretKey"
                ];
                return
                new
                Mailjet.Client.MailjetClient(apiKey, secretKey);
            });


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
