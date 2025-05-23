using TheMeaningDiscordancy.Api.Extensions;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigurationManager configuration = builder.Configuration;
        configuration.AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
            .AddJsonFile("appsettings.Local.json", optional: true);

        builder.Services.ConfigureStartupServices(configuration);

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("AllowFrontend");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.UseStaticFiles();

        app.Run();
    }
}
