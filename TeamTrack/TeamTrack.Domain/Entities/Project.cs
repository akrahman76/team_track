using System;
using System.Collections.Generic;
using System.Text;
using TeamTrack.Domain.Common;

namespace TeamTrack.Domain.Entities
{
    public class Project : BaseEntity
    {
        public Guid OrganizationId { get; private set; }
        public string Name { get; private set; }

        private Project() { }

        public Project(Guid organizationId, string name)
        {
            OrganizationId = organizationId;
            Name = name;
        }
    }
}
