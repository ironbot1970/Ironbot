using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

public class IronBotDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("Server=db4free.net;Port=3306;Database=ironbot1970;User Id=ironbotuser1970;Password=IronBotktch1970;",
            new MySqlServerVersion(new Version(8, 0, 23))); // Az adott MySQL verziótól függően változhat
    }

    // További DbSet-ek és modell osztályok itt...
}