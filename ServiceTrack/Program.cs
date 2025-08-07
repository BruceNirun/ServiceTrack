using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;
using ServiceTrack.Components;
using ServiceTrack.Data;
using ServiceTrack.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDb>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepairService, RepairService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices(); 

// เพิ่มบรรทัดนี้เพื่อลงทะเบียนคลาสแปลภาษาไทยของเรา
builder.Services.AddScoped(typeof(MudLocalizer), typeof(ThaiMudLocalizer));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();