using System;
using Microsoft.AspNetCore.Identity;
using TeamTrack.Domain.Entities;

namespace TeamTrack.Infrastructure.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public User DomainUser { get; private set; } = default!;

    private ApplicationUser() { }

    public ApplicationUser(User domainUser)
    {
        DomainUser = domainUser;
        Id = domainUser.Id;
        UserName = domainUser.Email;
        NormalizedUserName = domainUser.Email.ToUpperInvariant();
        Email = domainUser.Email;
        NormalizedEmail = domainUser.Email.ToUpperInvariant();
        EmailConfirmed = false;
    }
}
