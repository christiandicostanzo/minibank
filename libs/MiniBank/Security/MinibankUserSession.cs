using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Security.Claims;
using System.Text;
using ZstdSharp.Unsafe;

namespace MiniBank.Security;

public sealed class MinibankUser
{   

    internal MinibankUser(ClaimsPrincipal claimsPrincipal)
    {
        if(claimsPrincipal == null)
        {
            throw new ArgumentNullException(nameof(claimsPrincipal));
        }

        InitializeFromClaimsPrincipal(claimsPrincipal);
    }

    public Guid UserId { get; private set; } = Guid.Empty;
    public string Email { get; private set; } = string.Empty;
    public List<string> Roles { get; private set; } = new List<string>();

    private void InitializeFromClaimsPrincipal(ClaimsPrincipal claimsPrincipal)
    {
        if (claimsPrincipal == null || !claimsPrincipal.Identity.IsAuthenticated)
        {
            return;
        }
        var userIdClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim != null && Guid.TryParse(userIdClaim.Value, out Guid userId))
        {
            UserId = userId;
        }
        var emailClaim = claimsPrincipal.FindFirst(ClaimTypes.Email);
        if (emailClaim != null)
        {
            Email = emailClaim.Value;
        }
        foreach (var roleClaim in claimsPrincipal.FindAll(ClaimTypes.Role))
        {
            Roles.Add(roleClaim.Value);
        }
    }

    public bool IsInRole(string role)
    {
        return Roles.Contains(role);
    }   

}

public class MinibankUserSession
{

    private static MinibankUser _minibankUser;
    public static MinibankUser Instance
    {
        get 
        {
            return _minibankUser;
        }
    }

    public static void BuildFromJWT(ClaimsPrincipal claimsPrincipal)
    {
        _minibankUser = new MinibankUser(claimsPrincipal);
    }

}



