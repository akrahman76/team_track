using System;
using System.Collections.Generic;
using System.Text;
using TeamTrack.Domain.Common;

namespace TeamTrack.Domain.Entity
{
    public class Organization : BaseEntity
    {
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
    }
}
