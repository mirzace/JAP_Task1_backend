using api.Entities;
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

            var screenplayData = await System.IO.File.ReadAllTextAsync("Data/ScreenplaySeedData.json");
            var screenplays = JsonSerializer.Deserialize<List<Screenplay>>(screenplayData);

            foreach (var screenplay in screenplays)
            {
                context.Screenplays.Add(screenplay);
            }

            await context.SaveChangesAsync();
        }
    }
}
