using Autofac.Extensions.DependencyInjection;
using Autofac;
using SmartHealthcare.Service.UserInfo;
using SmartHealthcare.Service;
using SmartHealthcare.Infrastructure;
using SmartHealthcare.Api;
using log4net.Config;
using log4net;
using static SmartHealthcare.Api.log4net.Log4net;
using FluentAssertions.Common;
using MrHuo.OAuth;
using MrHuo.OAuth.Wechat;

var builder = WebApplication.CreateBuilder(args);//������ģʽ

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region AutoMapperע��

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));//automapper����

#endregion

#region AutoFac����ע������

//Autofac�Զ�ע��
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacModuleRegister());
});

#endregion

#region Startup Nlog4net����

Log4netHelper.Repository = LogManager.CreateRepository("NETCoreRepository");
XmlConfigurator.Configure(Log4netHelper.Repository, new FileInfo(Environment.CurrentDirectory + "/Config/log4net.config"));

#endregion

#region Oauth2.0

builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton(new WechatOAuth(OAuthConfig.LoadFrom(null, "oauth:wechat")));

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseAuthentication(); //��¼��֤����

app.UseHttpsRedirection();
app.UseCors(a => a.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); //����������վ���з���

app.UseAuthorization();

#region �����֤����Ȩ

app.UseAuthentication();//�����֤
app.UseAuthorization();//��Ȩ

#endregion

app.MapControllers();

app.Run();
