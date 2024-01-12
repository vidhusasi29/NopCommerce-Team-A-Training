using Authentication.API.Models;
using Contracts;
using Entities.Models;
using Entities.Models.ContentManagement;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System.Text;
using static Contracts.ICatalog;
using static Contracts.IPromotions;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.


builder.Services.AddDbContext<ContextDB>(optionsAction: options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("connectDB")));
builder.Services.AddDbContext<AuthenticationContext>(optionsAction: options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("connectDB")));
builder.Services.AddControllers();

builder.Services.AddScoped<ICustomers, Customerrepo>();
builder.Services.AddScoped<IVendors, Customerrepo>();
builder.Services.AddScoped<IAddress, Customerrepo>();
builder.Services.AddScoped<INewsItems, NewsItemsRepository>();
builder.Services.AddScoped<Contracts.IPromotions.IDiscounts, PromotionsRepo>();
builder.Services.AddScoped<IAffiliates,PromotionsRepo>();
builder.Services.AddScoped<INewsletter, PromotionsRepo>();
builder.Services.AddScoped<ICampaigns, PromotionsRepo>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IManufacturerRepository, ManufactureRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthenticationContext>()
    .AddDefaultTokenProviders();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Adding Jwt Bearer
   .AddJwtBearer(options =>
   {
       options.SaveToken = true;
       options.RequireHttpsMetadata = false;
       options.TokenValidationParameters = new TokenValidationParameters()
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidAudience = configuration["JWT:ValidAudience"],
           ValidIssuer = configuration["JWT:ValidIssuer"],
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
       };
   });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
