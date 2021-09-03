using api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace api.Data
{
    public class Seed
    {
        public static async Task SeedScreenplays(DataContext context)
        {
            if (await context.Screenplays.AnyAsync()) return;
            if (await context.Actors.AnyAsync()) return;

            var screenplayData = await System.IO.File.ReadAllTextAsync("Data/ScreenplaySeedData.json");
            var screenplays = JsonSerializer.Deserialize<List<Screenplay>>(screenplayData);

            var actorData = await System.IO.File.ReadAllTextAsync("Data/ActorSeedData.json");
            var actors = JsonSerializer.Deserialize<List<Actor>>(actorData);

            foreach (var actor in actors)
            {
                context.Actors.Add(actor);
            }

            foreach (var screenplay in screenplays)
            {
                context.Screenplays.Add(screenplay);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            if (users == null) return;

            var roles = new List<AppRole>
            {
                new AppRole { Name = "Consumer"}
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();
                await userManager.CreateAsync(user, "Test123");
                await userManager.AddToRoleAsync(user, "Consumer");
            }
        }
    }
}
