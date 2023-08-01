using System.Reflection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using SweetAcademy.Data.Models;
using static SweetAcademy.Common.GeneralApplicationConstants;


namespace SweetAcademy.Web.Infrastructure.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        /// <summary>
        /// This method registers all services with their interfaces and implementations of given assembly.
        /// The assembly is taken from the type of random service interface or implementation provided.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);
            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid service type provided!");
            }

            Type[] implementationTypes = serviceAssembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();
            foreach (Type implementationType in implementationTypes)
            {
                Type? interfaceType = implementationType
                    .GetInterface($"I{implementationType.Name}");
                if (interfaceType == null)
                {
                    throw new InvalidOperationException(
                        $"No interface is provided for the service with name: {implementationType.Name}");
                }

                services.AddScoped(interfaceType, implementationType);
            }
        }


        /// <summary>
        /// This method seeds first Admin if there is no created yet, only for development env.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="adminEmail"></param>
        /// <returns>applicationBuilder</returns>
        public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app, string adminEmail)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();
            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            UserManager<ApplicationUser> userManager =
                serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            RoleManager<IdentityRole<Guid>> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(RoleAdminName))
                    {
                        return;
                    }

                    var role = new IdentityRole<Guid>(RoleAdminName);
                    await roleManager.CreateAsync(role);

                    var adminUser = await userManager.FindByEmailAsync(adminEmail);
                    await userManager.AddToRoleAsync(adminUser, RoleAdminName);
                })
                .GetAwaiter()
                .GetResult();

            return app;
        }
    }
}