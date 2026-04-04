using System;
using System.Collections.Generic;
using System.Text;
using TeamTrack.Domain.Common;

namespace TeamTrack.Domain.Entities
{
    public class Project : BaseEntity
    {
        public Guid Id { get; private set; }
        public Guid OrganizationId { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }

        private Project() { }

        public Project(Guid organizationId, string name)
        {
            OrganizationId = organizationId;
            Name = name;
        }

        public static Project Create(
            Guid organizationId,
            string name,
            string? description)
        {
            var project = new Project
            {
                Id = Guid.NewGuid(),
                OrganizationId = organizationId,
                Name = name,
                Description = description
            };

            return project;
        }
    }
}
