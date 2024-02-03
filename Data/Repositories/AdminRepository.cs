using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Repositories;

namespace Data.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ProkonContext db;

        public AdminRepository(ProkonContext db)
        {
            this.db = db;
        }

        public async Task<List<IdentityUser>> GetAdmins()
        {
            var adminRole = await db.Roles
                                   .FirstOrDefaultAsync(r => r.Name == "Admin");

            var userIds = await db.UserRoles
                                    .Where(ur => ur.RoleId == adminRole.Id)
                                    .Select(ur => ur.UserId)
                                    .ToListAsync();

            var admins = await db.Users
                                    .Where(u => userIds.Any(id => id == u.Id))
                                    .ToListAsync();

            return admins;
        }
    }
}
