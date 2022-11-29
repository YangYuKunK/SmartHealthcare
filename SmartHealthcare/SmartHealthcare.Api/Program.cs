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

var builder = WebApplication.CreateBuilder(args);//建造者模式

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.IConfiguration();

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

#region Oauth2.0

builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton(new WechatOAuth(OAuthConfig.LoadFrom(null, "oauth:wechat")));

#endregion

#region Jwt相关配置
// 配置Authentication服务
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // 验证方式
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // 质询方式

}).AddJwtBearer(
    x =>
    {
        // 对JwtBearer进行配置
        x.RequireHttpsMetadata = true;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters()
        {
            // Token验证参数
            ValidateIssuer = true, // 是否验证Issuer
            ValidIssuer = "xiaoyu",
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yangyukunpassword")), // 秘钥（至少16位）
            ValidateAudience = true,
            ValidAudience = "everyone",
            ValidateLifetime = true,
            //RoleClaimType= "everyone",
            ClockSkew = TimeSpan.FromMinutes(30) // 对token过期时间验证的允许时间
        };
    }
    );

#endregion

#region Swagger相关配置
builder.Services.AddSwaggerGen(c =>
{

    var basePath = AppContext.BaseDirectory;  // 获取应用程序的所在目录
    var xmlPath = System.IO.Path.Combine(basePath, "SmartHealthcare.Api.xml"); // 拼接XML文件所在路径
                                                                               // 让Swagger显示方法、类的XML注释信息
    c.IncludeXmlComments(xmlPath, true);
    #region Swagger文档参数
    // 设置Swagger文档参数
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TodoApi",
        Version = "v1",
        Description = "Asp.Net Core5 WebApi Jwt认证", // 描述信息
        Contact = new OpenApiContact() // 开发者信息
        {
            Name = "小宇",
            Email = "2862547662@qq.com",
            Url = new Uri("https://gitee.com/yuyou_x/live-ecommerce.git")
        }
    });
    #endregion

    #region Authorize权限认证按钮
    ////开启Authorize权限按钮
    //c.AddSecurityDefinition("JWTBearer", new OpenApiSecurityScheme()
    //{
    //    Description = "这是方式一(直接在输入框中输入认证信息，不需要在开头添加Bearer) ",
    //    Name = "Authorization", // jwt默认的参数名称
    //    In = ParameterLocation.Header, // jwt默认存放Authorization信息的位置(请求头中)
    //    Type = SecuritySchemeType.Http,
    //    Scheme = "Bearer"
    //});

    //定义JwtBearer认证方式二
    c.AddSecurityDefinition("JwtBearer", new OpenApiSecurityScheme()
    {
        Description = "这是方式二(JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）)",
        Name = "Authorization",//jwt默认的参数名称
        In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
        Type = SecuritySchemeType.ApiKey
    });

    #endregion

    // 声明一个Scheme，注意下面的Id要和上面AddSecurityDefinition中的参数name一致
    var scheme = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference()
        {
            Id = "JWTBearer",   //这个名字与上面的一样
            Type = ReferenceType.SecurityScheme
        }
    };
    // 注册全局认证（所有的接口都可以使用认证）
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { scheme, Array.Empty<string>() }
                });
});
#endregion

#region 接口连接(依赖注入(接口方式))
builder.Services.AddScoped<IJwtuser, JwtUser>(); // jwt注入接口

// 获取jwt配置并完成注入
var jwtConfig = builder.Configuration.GetSection("JWTConfig").Get<JwtConfig>();
builder.Services.AddSingleton(jwtConfig); // Jwt注入

#endregion

#region Startup Nlog4net配置

Log4netHelper.Repository = LogManager.CreateRepository("NETCoreRepository");
XmlConfigurator.Configure(Log4netHelper.Repository, new FileInfo(Environment.CurrentDirectory + "/Config/log4net.config"));

#endregion

#region 授权过滤器配置
builder.Services.AddAuthentication
    (
        Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme
    ).AddCookie
    (
        Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme, o =>
        {
            o.LoginPath = new PathString("/User/SelectUserInfo");//未经过授权过滤器，返回到登录页面
        }
    );

/*
 * 添加身份认证 使用默认的名称public const string AuthenticationScheme="Cookies";
 * 添加配置（委托的方式）：配置无权限时跳转的页面
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

app.UseAuthentication(); //登录验证机制

app.UseHttpsRedirection();
app.UseCors(a => a.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); //允许所有网站进行访问

app.UseAuthorization();

#region 身份认证及授权

app.UseAuthentication();//身份认证
app.UseAuthorization();//授权

#endregion

app.MapControllers();

app.Run();
