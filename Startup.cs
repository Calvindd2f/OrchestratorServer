using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrchestratorServer.Data;
using OrchestratorServer.Repositories;
using OrchestratorServer.Services;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        services.AddDistributedMemoryCache();
        services.AddSession();

        // Register repositories
        services.AddScoped<IConditionRepository, ConditionRepository>();
        services.AddScoped<IActivityRepository, ActivityRepository>();
        services.AddScoped<IWorkflowRepository, WorkflowRepository>();

        // Register services
        services.AddScoped<IConditionService, ConditionService>();
        services.AddScoped<IActivityService, ActivityService>();
        services.AddScoped<IWorkflowService, WorkflowService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseSession();

        app.UseMiddleware<ExceptionHandlerMiddleware>();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
