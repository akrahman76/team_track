using System;
using System.Collections.Generic;
using System.Text;
using TeamTrack.Domain.Common;
using TeamTrack.Domain.Enums;

namespace TeamTrack.Domain.Entities
{
    public class OrganizationMember : BaseEntity
    {
        public Guid OrganizationId { get; private set; }
        public Guid UserId { get; private set; }
        public OrganizationRole Role { get; private set; }

        private OrganizationMember() { }

        public OrganizationMember(Guid organizationId, Guid userId, OrganizationRole role)
        {
            OrganizationId = organizationId;
            UserId = userId;
            Role = role;
        }
    }
}
