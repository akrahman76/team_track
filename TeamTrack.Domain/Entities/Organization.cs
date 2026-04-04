using System;
using System.Collections.Generic;
using System.Text;
using TeamTrack.Domain.Common;

namespace TeamTrack.Domain.Entities
{
    public class Organization : BaseEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = default!;

        private readonly List<OrganizationMember> _members = new();
        public IReadOnlyCollection<OrganizationMember> Members => _members.AsReadOnly();

        private Organization() { }
        public Organization(string name)
        {
            Name = name;
        }

        public void AddMember(OrganizationMember member)
        {
            _members.Add(member);
        }

        public static Organization Create(string name)
        {
            return new Organization
            {
                Id = Guid.NewGuid(),
                Name = name
            };
        }
    }
}
