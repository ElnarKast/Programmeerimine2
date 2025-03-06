using KooliProjekt.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;

public static class SeedData
{
    public static void Generate(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        if (context.Building.Any())
        {
            return;
        }

        IdentityUser user;

        if (context.Users.Count() == 0)
        {
            user = new IdentityUser
            {
                UserName = "newuser@example.com",
                Email = "newuser@example.com",
                NormalizedUserName = "NEWUSER@EXAMPLE.COM", // Optional but recommended for case-insensitivity
                NormalizedEmail = "NEWUSER@EXAMPLE.COM" // Optional but recommended
            };

            // Create the user with a password
            userManager.CreateAsync(user, "Password123!").Wait();
        }
        else
        {
            user = context.Users.First();
        }

        var material1 = new Material();
        material1.Name = "Iron";
        material1.UnitPrice = 15.5m;
        context.Material.Add(material1);

        var panel1 = new Panel();
        context.Panel.Add(panel1);

        var building1 = new Building();
        building1.User = user;
        building1.UserId = user.Id;
        building1.Date = DateTime.Now;
        building1.Location = "New York";
        context.Building.Add(building1);

        var service1 = new Service();
        service1.Building = building1;
        service1.Price = 10;
        context.Service.Add(service1);

        var panel_materials1 = new PanelMaterial();
        panel_materials1.Amount = 100m;
        panel_materials1.Material = material1;
        panel_materials1.Panel = panel1;
        panel_materials1.UnitPrice = 5;
        panel_materials1.TotalPrice = 500;
        context.PanelMaterial.Add(panel_materials1);

        var building_panels1 = new BuildingPanels();
        building_panels1.Amount = 10;
        building_panels1.Building = building1;
        building_panels1.Panel = panel1;
        context.BuildingPanels.Add(building_panels1);

        // Veel andmeid

        context.SaveChanges();
    }
}