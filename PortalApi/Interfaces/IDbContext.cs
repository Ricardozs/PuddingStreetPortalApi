using PortalApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApi.Interfaces
{
    public interface IDbContext
    {
        bool CreateUser(User user);
        bool AddCandidate(Candidate candidate);
        bool ValidatePassword(string user, string password);
    }
}
