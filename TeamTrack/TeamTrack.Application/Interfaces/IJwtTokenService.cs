using System;

namespace TeamTrack.Application.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(Guid userId, string email, IEnumerable<string> roles);
}
