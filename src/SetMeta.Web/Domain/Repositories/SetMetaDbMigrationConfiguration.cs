﻿using System;
using System.Data.Entity.Migrations;
using System.Linq;
using SetMeta.Web.Helpers;
using SetMeta.Web.Domain.Entities;

namespace SetMeta.Web.Domain.Repositories
{
    public class SetMetaDbMigrationConfiguration : DbMigrationsConfiguration<SetMetaDbContext>
    {
        public SetMetaDbMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SetMetaDbContext context)
        {
            if (context.Users.Any()) return;

            #region Users

            AddAdmin(context, "Serdar Büyüktemiz", "hserdarb@gmail.com");
            AddAdmin(context, "Caner Çavuş", "canercvs@gmail.com");
            AddAdmin(context, "Ramiz Sümer", "ramiz.sumerr@gmail.com");
            AddAdmin(context, "Mehmet Sabancıoğlu", "mehmet.sabancioglu@gmail.com");
            AddAdmin(context, "Cihan Çoşkun", "cihancoskun@gmail.com");
            AddAdmin(context, "Kemal Çolak", "kml.colak@gmail.com");
            AddAdmin(context, "Duygu Sevim", "sevimduygu@gmail.com");

            //todo: temporary add myself as admin for tests
            AddAdmin(context, "Max Voloshin", "mx.voloshin@gmail.com");

            #endregion

        }
        private static void AddAdmin(SetMetaDbContext context, string name, string email)
        {
            var user = new User
            {
                Email = email,
                Name = name,
                RoleId = SetLocaleRole.Admin.Value,
                RoleName = SetLocaleRole.Admin.ToString(),
                ImageUrl = GravatarHelper.GetGravatarURL(email, 35),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("password"),
                LastLoginAt = DateTime.Now,
                IsActive = true
            };
            context.Users.Add(user);
        }
    }
}