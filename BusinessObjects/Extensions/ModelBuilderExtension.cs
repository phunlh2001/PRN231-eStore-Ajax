using BusinessObjects.Constant;
using BusinessObjects.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BusinessObjects.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void SetUp(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().HasKey(o => new
            {
                o.ProductId,
                o.OrderId
            });
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Apple" },
                new Category { CategoryId = 2, CategoryName = "Samsung" },
                new Category { CategoryId = 3, CategoryName = "Nokia" }
            );
        }

        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            var userManager = service.GetService<UserManager<Member>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

            var user = new Member
            {
                UserName = "admin@estore.com",
                Email = "admin@estore.com",
                FirstName = "Kaizz",
                LastName = "Nguyen",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var userExist = await userManager.FindByEmailAsync(user.Email);
            if (userExist == null)
            {
                await userManager.CreateAsync(user, "admin@@");
                await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
            }
        }
    }
}
