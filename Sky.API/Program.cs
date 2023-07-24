using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Sky.API.Configuration;
using Sky.Domain;
using Sky.Domain.Entities;
using Sky.Infrastructure;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// JWT Config
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*---------------------------------------------------------------------------------------------------*/
/*                                   Enable CORS                                                     */
/*---------------------------------------------------------------------------------------------------*/
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Json Serializer
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options=> options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options=>options.SerializerSettings.ContractResolver = new DefaultContractResolver());

builder.Services.AddSingleton<IDatabaseConnectionString>((serviceProvider) => new DatabaseConnectionString(connectionString: builder.Configuration.GetConnectionString("SkyDB")));
//builder.Services.AddDatabaseConectionStrings(builder.Configuration);
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();



builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwt =>
{
    var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtConfig:SecretKey"]);

    jwt.SaveToken = true;
    jwt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateLifetime = true,
        RequireExpirationTime = false,
        //ClockSkew = TimeSpan.Zero
    };
});
//builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true) 
//    .AddEntityFrameworkStores<SkyDBContext>();







var app = builder.Build();


//Enable CORS
app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

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
