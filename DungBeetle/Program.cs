using DungBeetle.Applications.Common.Interfaces;
using DungBeetle.Applications.WorkSchedule;
using DungBeetle.Client.Pages;
using DungBeetle.Components;
using DungBeetle.Infra.Apis;

namespace DungBeetle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            builder.Services.AddHttpClient();
            builder.Services.AddSingleton(TimeProvider.System);
            builder.Services.AddSingleton<IOpenApi, OpenApi>();
            builder.Services.AddScoped<WorkScheduleHandler>();

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Counter).Assembly);

            app.Run();
        }
    }
}
