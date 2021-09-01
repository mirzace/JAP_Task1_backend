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
        /*
        Title: '{{company()}}',
        Description: '{{lorem(1, "paragraphs")}}',
        ReleaseDate: '{{date(new Date(2019, 0, 1), new Date(2020,5,30), "YYYY-MM-dd")}}',
        Category: '{{random("movie", "show")}}'
        */

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
    }
}
