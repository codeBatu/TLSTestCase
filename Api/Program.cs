using Busiines.Abstract;
using Busiines.Concrete;
using Microsoft.AspNetCore.Hosting;
using Model;
using Repository;
using Repository.Models;
using Repository.RepositoryInterface;
using AutoMapper;
using Busiines.Helpers;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AutoMapperProfile()); // AutoMapper profillerini burada ekleyin
        });
        builder. Services.AddCors();
        // IMapper hizmetini ekleyin
        var mapper = mapperConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IDocumentSupply, DocumentManager>();
        builder.Services.AddScoped<IAccountSupply, AccountManager>();
        builder.Services.AddScoped<IAccountRepository, AccountRepository>();
        builder.Services.AddScoped<IDocumentRepository<Document>, DocumentRepository>();
        builder.Services.AddScoped<TestCaseContext>();
        // AutoMapper yapılandırması
  





        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors(x => x
      .SetIsOriginAllowed(origin => true)
      .AllowAnyMethod()
      .AllowAnyHeader()
      .AllowCredentials());

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}