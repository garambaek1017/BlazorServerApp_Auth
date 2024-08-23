using BlazorServerAppForAuthentication.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlazorServerAppForAuthentication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private HttpContext _httpContext;

    //Di
    public AuthController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _httpContext = _httpContextAccessor.HttpContext;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        Console.WriteLine($"[API/Login] ID:{model.Id}, PW:{model.Pw}");

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, model.Id)
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        // 인증 쿠키 설정
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = false,
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
        };

        await _httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);

        Console.WriteLine(
            "cookie : " + _httpContext.Response.Headers.Cookie);
        // test를 위해 일단 무조건 ok 처리 
        return Ok();
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        Console.WriteLine($"[API/Logout]");
        await _httpContext.SignOutAsync();
        return Ok();
    }
}

