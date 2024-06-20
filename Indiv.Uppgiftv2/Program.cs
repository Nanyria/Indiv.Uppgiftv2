
using AutoMapper;
using Indiv.Uppgiftv2.Data;
using Indiv.Uppgiftv2.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Indiv.Uppgiftv2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost",
                    policy => policy.WithOrigins("https://localhost:7203", "http://localhost:5026")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod());
            });


            builder.Services.AddLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
                logging.AddDebug();
                logging.SetMinimumLevel(LogLevel.Debug);
            });

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                // Add JWT authentication to Swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter into field the word 'Bearer' followed by a space and the JWT token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://localhost",
                        ValidAudience = "https://localhost",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("G7DkUJneKl1Z3YRpQF6sjV8hT3mC9gX5")),
                        ClockSkew = TimeSpan.Zero // Reduce clock skew to avoid timing issues
                    };
                });

            builder.Services.AddAuthorization();

            builder.Services.AddScoped<ICustomer, CustomerRepo>();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowLocalhost");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
    //    {
    //        var builder = WebApplication.CreateBuilder(args);

    //        builder.Services.AddCors(options =>
    //        {
    //            options.AddPolicy("AllowLocalhost",
    //                policy => policy.WithOrigins("http://localhost:5026")
    //                                .AllowAnyHeader()
    //                                .AllowAnyMethod());
    //        });


    //        // Add services to the container.
    //        builder.Services.AddControllers().AddJsonOptions(options =>
    //        {
    //            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.
    //            Serialization.ReferenceHandler.IgnoreCycles;
    //        });
    //        builder.Services.AddControllers();
    //        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    //        builder.Services.AddEndpointsApiExplorer();
    //        builder.Services.AddSwaggerGen(c =>
    //        {
    //            c.SwaggerDoc("v1", new() { Title = "My API", Version = "v1" });

    //            // Add JWT authentication to Swagger
    //            c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    //            {
    //                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
    //                Description = "Please enter into field the word 'Bearer' followed by a space and the JWT token",
    //                Name = "Authorization",
    //                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
    //                BearerFormat = "JWT",
    //                Scheme = "Bearer"
    //            });
    //            c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    //{
    //    {
    //        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    //        {
    //            Reference = new Microsoft.OpenApi.Models.OpenApiReference
    //            {
    //                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
    //                Id = "Bearer"
    //            }
    //        },
    //        new string[] { }
    //    }
    //});
    //        });

    //        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    //            .AddJwtBearer(options =>
    //            {
    //                options.TokenValidationParameters = new TokenValidationParameters
    //                {
    //                    ValidateIssuer = true,
    //                    ValidateAudience = true,
    //                    ValidateLifetime = true,
    //                    ValidateIssuerSigningKey = true,
    //                    ValidIssuer = "http://localhost",
    //                    ValidAudience = "http://localhost",
    //                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("G7DkUJneKl1Z3YRpQF6sjV8hT3mC9gX5"))
    //                };
    //            });

    //        builder.Services.AddAuthorization();

    //        builder.Services.AddScoped<ICustomer, CustomerRepo>();
    //        builder.Services.AddDbContext<AppDbContext>(options =>
    //      options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    //        var app = builder.Build();


    //        // Configure the HTTP request pipeline.
    //        if (app.Environment.IsDevelopment())
    //        {
    //            app.UseSwagger();
    //            app.UseSwaggerUI();
    //        }
    //        app.UseCors("AllowLocalhost");
    //        app.UseAuthentication();
    //        app.UseHttpsRedirection();
    //        app.UseAuthorization();


    //        app.MapControllers();

    //        app.Run();
    //    }
    

