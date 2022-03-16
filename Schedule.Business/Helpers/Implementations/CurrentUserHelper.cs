using Microsoft.AspNetCore.Http;
using Schedule.Business.Helpers.Interfaces;
using Schedule.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Schedule.Business.Services.Implementations
{
    internal class CurrentUserHelper : ICurrentUserAccessor
    {
        private readonly IEnumerable<Claim> claims;

        public CurrentUserHelper(IHttpContextAccessor httpContextAccessor)
        {
            this.claims = httpContextAccessor?.HttpContext?.User?.Claims ?? Enumerable.Empty<Claim>();
        }

        private Guid? _id = null;
        public Guid? Id
        {
            get
            {
                if (!_id.HasValue)
                {
                    _id = Guid.TryParse(claims?.FirstOrDefault(i => i.Type == ClaimTypes.Sid)?.Value, out var id) ? id : (Guid?)null;
                }
                return _id;
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                if (string.IsNullOrEmpty(_email))
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
                if (!_role.HasValue)
                {
                    _role = Enum.TryParse(claims?.FirstOrDefault(i => i.Type == ClaimTypes.Role)?.Value, out Role role) ? role : (Role?)null;
                }
                return _role;
            }
        }
    }
}
