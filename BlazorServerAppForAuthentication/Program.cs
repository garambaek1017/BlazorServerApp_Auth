using BlazorServerAppForAuthentication.Components;
using BlazorServerAppForAuthentication.Utilites;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddControllers();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.Cookie.Name = CookieAuthenticationDefaults.AuthenticationScheme; // ��Ű �̸� ���� 
    opt.Cookie.Path = "/";
    // HTTPS�θ� ��Ű�� ����
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    // ����ڰ� Ȱ���� ������ ��Ű ���� �ð��� ����
    opt.SlidingExpiration = true;
});
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CookieStorageAccessor>();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();
app.MapControllers();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
