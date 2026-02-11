using System;
using TeamTrack.Domain.Entities;

namespace TeamTrack.Application.Common.Interfaces;

public interface IOrganizationRepository
{
    void Add(Organization organization);
}
