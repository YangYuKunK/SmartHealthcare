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
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SmartHealthcare.Api.JWT;

var builder = WebApplication.CreateBuilder(args);//������ģʽ

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.IConfiguration();

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

#region Oauth2.0

builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton(new WechatOAuth(OAuthConfig.LoadFrom(null, "oauth:wechat")));

#endregion

#region Jwt�������
// ����Authentication����
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // ��֤��ʽ
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // ��ѯ��ʽ

}).AddJwtBearer(
    x =>
    {
        // ��JwtBearer��������
        x.RequireHttpsMetadata = true;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters()
        {
            // Token��֤����
            ValidateIssuer = true, // �Ƿ���֤Issuer
            ValidIssuer = "xiaoyu",
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yangyukunpassword")), // ��Կ������16λ��
            ValidateAudience = true,
            ValidAudience = "everyone",
            ValidateLifetime = true,
            //RoleClaimType= "everyone",
            ClockSkew = TimeSpan.FromMinutes(30) // ��token����ʱ����֤������ʱ��
        };
    }
    );

#endregion

#region Swagger�������
builder.Services.AddSwaggerGen(c =>
{

    var basePath = AppContext.BaseDirectory;  // ��ȡӦ�ó��������Ŀ¼
    var xmlPath = System.IO.Path.Combine(basePath, "SmartHealthcare.Api.xml"); // ƴ��XML�ļ�����·��
                                                                               // ��Swagger��ʾ���������XMLע����Ϣ
    c.IncludeXmlComments(xmlPath, true);
    #region Swagger�ĵ�����
    // ����Swagger�ĵ�����
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TodoApi",
        Version = "v1",
        Description = "Asp.Net Core5 WebApi Jwt��֤", // ������Ϣ
        Contact = new OpenApiContact() // ��������Ϣ
        {
            Name = "С��",
            Email = "2862547662@qq.com",
            Url = new Uri("https://gitee.com/yuyou_x/live-ecommerce.git")
        }
    });
    #endregion

    #region AuthorizeȨ����֤��ť
    ////����AuthorizeȨ�ް�ť
    //c.AddSecurityDefinition("JWTBearer", new OpenApiSecurityScheme()
    //{
    //    Description = "���Ƿ�ʽһ(ֱ�����������������֤��Ϣ������Ҫ�ڿ�ͷ���Bearer) ",
    //    Name = "Authorization", // jwtĬ�ϵĲ�������
    //    In = ParameterLocation.Header, // jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
    //    Type = SecuritySchemeType.Http,
    //    Scheme = "Bearer"
    //});

    //����JwtBearer��֤��ʽ��
    c.AddSecurityDefinition("JwtBearer", new OpenApiSecurityScheme()
    {
        Description = "���Ƿ�ʽ��(JWT��Ȩ(���ݽ�������ͷ�н��д���) ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�)",
        Name = "Authorization",//jwtĬ�ϵĲ�������
        In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
        Type = SecuritySchemeType.ApiKey
    });

    #endregion

    // ����һ��Scheme��ע�������IdҪ������AddSecurityDefinition�еĲ���nameһ��
    var scheme = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference()
        {
            Id = "JWTBearer",   //��������������һ��
            Type = ReferenceType.SecurityScheme
        }
    };
    // ע��ȫ����֤�����еĽӿڶ�����ʹ����֤��
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { scheme, Array.Empty<string>() }
                });
});
#endregion

#region �ӿ�����(����ע��(�ӿڷ�ʽ))
builder.Services.AddScoped<IJwtuser, JwtUser>(); // jwtע��ӿ�

// ��ȡjwt���ò����ע��
var jwtConfig = builder.Configuration.GetSection("JWTConfig").Get<JwtConfig>();
builder.Services.AddSingleton(jwtConfig); // Jwtע��

#endregion

#region Startup Nlog4net����

Log4netHelper.Repository = LogManager.CreateRepository("NETCoreRepository");
XmlConfigurator.Configure(Log4netHelper.Repository, new FileInfo(Environment.CurrentDirectory + "/Config/log4net.config"));

#endregion

#region ��Ȩ����������
builder.Services.AddAuthentication
    (
        Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme
    ).AddCookie
    (
        Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme, o =>
        {
            o.LoginPath = new PathString("/User/SelectUserInfo");//δ������Ȩ�����������ص���¼ҳ��
        }
    );

/*
 * ��������֤ ʹ��Ĭ�ϵ�����public const string AuthenticationScheme="Cookies";
 * ������ã�ί�еķ�ʽ����������Ȩ��ʱ��ת��ҳ��
 */
//services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(config=>config.LoginPath= "/Login/Login");

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartHealthcare.Api v1"));
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
