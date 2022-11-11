using Autofac.Extensions.DependencyInjection;
using Autofac;
using SmartHealthcare.Service.UserInfo;
using SmartHealthcare.Service;
using SmartHealthcare.Infrastructure;
using SmartHealthcare.Api;
using log4net.Config;
using log4net;
using static SmartHealthcare.Api.log4net.Log4net;

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

#region Startup Nlog4net配置

Log4netHelper.Repository = LogManager.CreateRepository("NETCoreRepository");
XmlConfigurator.Configure(Log4netHelper.Repository, new FileInfo(Environment.CurrentDirectory + "/Config/log4net.config"));

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


#region 身份认证及授权

app.UseAuthentication();//身份认证
app.UseAuthorization();//授权

#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
