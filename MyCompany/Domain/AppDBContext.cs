using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Entities
{
    public class AppDBContext: IdentityDbContext<IdentityUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "d073bcfb-9130-42f2-b1ec-90aae51dd079",
                Name = "admin",
                NormalizedName = "ADMIN"
            }) ;
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "9a7da232-b7fd-4a6a-8b06-ba227cb91990",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null,"superpassword"),
                SecurityStamp = string.Empty
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId= "d073bcfb-9130-42f2-b1ec-90aae51dd079",
                UserId = "9a7da232-b7fd-4a6a-8b06-ba227cb91990"
            });
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("7bb272e6-3940-4989-a271-c5df127c8519"),
                CodeWord = "PageIndex",
                Title = "Главная"
            });
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("caaeda72-c6b6-4673-8019-10faa98b1e83"),
                CodeWord = "PageServices",
                Title = "Наши услуги"
            });
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("21945cdb-7395-4a55-bd48-9de2d14a17e6"),
                CodeWord = "PageContacts",
                Title = "Контакты"
            });

        }
    }
}
