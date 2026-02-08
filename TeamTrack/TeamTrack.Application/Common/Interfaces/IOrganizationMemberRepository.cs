using System;
using TeamTrack.Domain.Entities;

namespace TeamTrack.Application.Common.Interfaces;

public interface IOrganizationMemberRepository
{
    void Add(OrganizationMember organizationMember);
}
