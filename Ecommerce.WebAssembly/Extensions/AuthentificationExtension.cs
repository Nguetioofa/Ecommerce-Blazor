using Blazored.LocalStorage;
using Ecommerce.DTO;
using Ecommerce.DTO.User;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;


namespace Ecommerce.WebAssembly.Extensions;

public class AuthentificationExtension : AuthenticationStateProvider
{
    private readonly ILocalStorageService   _localStorageService;
    private ClaimsPrincipal _principal = new(new ClaimsIdentity());

    public AuthentificationExtension(ILocalStorageService localStorageService)
    {
        _localStorageService =  localStorageService;
    }

    public async Task ActualiserStatutAuthentification(SessionDTO? sessionDTO)
    {
        ClaimsPrincipal claimsPrincipal = new();

        if (sessionDTO != null)
        {
            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, sessionDTO.IdUtilisateur.ToString()),
                new Claim(ClaimTypes.Name, sessionDTO.NomComplet),
                new Claim(ClaimTypes.Email, sessionDTO.Email),
                new Claim(ClaimTypes.Role, sessionDTO.Role)
            },"JwtAuth"));

            await _localStorageService.SetItemAsync("sessionUser", sessionDTO);
        }
        else
        {
            claimsPrincipal = _principal;
            await _localStorageService.RemoveItemAsync("sessionUser");
        }

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var sessionUser = await _localStorageService.GetItemAsync<SessionDTO>("sessionUser");
        if (sessionUser == null)
            return await Task.FromResult(new AuthenticationState(_principal));

       var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, sessionUser.IdUtilisateur.ToString()),
                new Claim(ClaimTypes.Name, sessionUser.NomComplet),
                new Claim(ClaimTypes.Email, sessionUser.Email),
                new Claim(ClaimTypes.Role, sessionUser.Role)
            }, "JwtAuth"));

        return await Task.FromResult(new AuthenticationState(claimsPrincipal));
    }
}
