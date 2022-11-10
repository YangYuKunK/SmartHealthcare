using Autofac.Extensions.DependencyInjection;
using Autofac;
using SmartHealthcare.Service.UserInfo;
using SmartHealthcare.Service;
using SmartHealthcare.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region AutoMapperע��

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));//automapper����

#endregion

var buliders = new ContainerBuilder();

#region AutoFac����ע������
IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory()) //����Autofac��ʵ������ע��
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Program>();
                });

buliders.RegisterAssemblyTypes(typeof(UserService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

buliders.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
