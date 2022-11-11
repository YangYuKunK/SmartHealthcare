using Autofac.Extensions.DependencyInjection;
using Autofac;
using SmartHealthcare.Service.UserInfo;
using SmartHealthcare.Service;
using SmartHealthcare.Infrastructure;
using SmartHealthcare.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region AutoMapper注入

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));//automapper依赖

#endregion


#region AutoFac依赖注入配置

//Autofac自动注入
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacModuleRegister());
});


#endregion


//#region AutoFac依赖注入配置
//IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//            .UseServiceProviderFactory(new AutofacServiceProviderFactory()) //改用Autofac来实现依赖注入
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Program>();
//                });

//buliders.RegisterAssemblyTypes(typeof(UserService).Assembly)
//                .Where(t => t.Name.EndsWith("Service"))
//                .AsImplementedInterfaces();

//buliders.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
//                .Where(t => t.Name.EndsWith("Repository"))
//                .AsImplementedInterfaces();

//#endregion

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
