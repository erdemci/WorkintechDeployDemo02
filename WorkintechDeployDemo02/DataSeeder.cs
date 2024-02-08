using Microsoft.EntityFrameworkCore;
using WorkintechDeployDemo02.Models;

namespace WorkintechDeployDemo02
{
    public static class DataSeeder
    {

        public static void SeedCodeFirst(IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<WorkintechSqliteContext>();

                if (context == null)
                    return;

                context.Database.Migrate();
                context.Database.EnsureCreated();

                #region CitySeed
                if (!context.Cities.Any())
                {
                    var cities = new List<City>()
                    {
                        new City(){Name="Ankara"},
                        new City(){Name="İstanbul"},
                        new City(){Name="İzmir"},
                        new City(){Name="Eskişehir"},
                        new City(){Name="Bursa"},
                    };
                    context.Cities.AddRange(cities);
                }
                #endregion


                context.SaveChanges();
            }
        }

    }
}
