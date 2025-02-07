using AutoMapper;
using Blazored.Modal;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Wassandashboard.Components;
using Wassandashboard.Components.Account;
using Wassandashboard.Data;
using Wassandashboard.Data.Extensions;
using Wassandashboard.Data.Services;
using Wassandashboard.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents().AddCircuitOptions(option =>
    {
        option.DetailedErrors = true;
        option.JSInteropDefaultCallTimeout = TimeSpan.FromMinutes(5);
    }); ;

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;

    })
    .AddIdentityCookies();

builder.Services.AddAuthorization(options =>
{
    AuthorizationExtensions.RegisterPermissionClaims(options);
});


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
var UserConnectionString = builder.Configuration.GetConnectionString("UserConnection")
    ?? throw new InvalidOperationException("Connection string 'User' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(UserConnectionString, new MySqlServerVersion(new Version(5, 6, 47)),
        options => options.EnableRetryOnFailure()));

builder.Services.AddDbContext<DashboardDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(5, 6, 47)),
           options => options.EnableRetryOnFailure()));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IDbContextFactory<DashboardDbContext>, DbContextFactory>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityEmailSender>();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSingleton<ExcelExportService>();
builder.Services.AddBlazoredModal();
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapAdditionalIdentityEndpoints();

app.Run();
