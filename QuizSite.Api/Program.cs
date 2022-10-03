using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuizSite.Domain.Database;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddDbContext<QuizDbContext>((options) => _ = options.UseNpgsql("User ID=postgres;Password=12345;Host=localhost;Port=5432;Database=FinalQuiz;"));
        builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        var app = builder.Build();

        app.UseFileServer();

        app.MapControllers();

        app.Run();
    }
}