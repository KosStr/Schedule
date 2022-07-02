using Microsoft.AspNetCore.Http;
using Schedule.Business.Helpers.Interfaces;
using Schedule.Core.Enums;
using Schedule.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Schedule.Business.Services.Implementations
{
    internal class CurrentUserHelper : ICurrentUser
    {
        private readonly IEnumerable<Claim> claims;

        public CurrentUserHelper(IHttpContextAccessor httpContextAccessor)
        {
            this.claims = httpContextAccessor?.HttpContext?.User?.Claims ?? Enumerable.Empty<Claim>();
        }

        private Guid? _userId = null;
        public Guid? UserId
        {
            get
            {
                if (!_userId.HasValue)
                {
                    _userId = Guid.TryParse(claims?.FirstOrDefault(i => i.Type == Constants.Claims.UserId)?.Value, out var userId) ? userId : Guid.Empty;
                }
                return _userId;
            }
        }

        private Guid? _groupId = null;
        public Guid? GroupId
        {
            get
            {
                if (!_groupId.HasValue)
                {
                    _groupId = Guid.TryParse(claims?.FirstOrDefault(i => i.Type == Constants.Claims.GroupId)?.Value, out var groupId) ? groupId : Guid.Empty;
                }
                return _groupId;
            }
        }

        private string _email = null;
        public string Email
        {
            get
            {
                if (String.IsNullOrEmpty(_email))
                {
                    _email = claims?.FirstOrDefault(i => i.Type == ClaimTypes.Email)?.Value;
                }
                return _email;
            }
        }

        private Role? _role = null;
        public Role? Role
        {
            get
            {
                if (_role == null)
                {
                    _role = Enum.TryParse(claims?.FirstOrDefault(i => i.Type == ClaimTypes.Role)?.Value, out Role role) ? role : (Role?)null;
                }
                return _role;
            }
        }

        private Guid? _facultyId = null;
        public Guid? FacultyId
        {
            get
            {
                if (!_facultyId.HasValue)
                {
                    _facultyId = Guid.TryParse(claims?.FirstOrDefault(i => i.Type == Constants.Claims.FacultyId)?.Value, out var facultyId) ? facultyId : Guid.Empty;
                }
                return _facultyId;
            }
        }

        private Guid? _organizationId = null;
        public Guid? OrganizationId
        {
            get
            {
                if (!_organizationId.HasValue)
                {
                    _organizationId = Guid.TryParse(claims?.FirstOrDefault(i => i.Type == Constants.Claims.OrganizationId)?.Value, out var organizationId) ? organizationId : Guid.Empty;
                }
                return _organizationId;
            }
        }
    }
}
