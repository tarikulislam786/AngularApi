using AngApi.DAL.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngApi.DAL.Model
{
    public class AuthenticationContext : IdentityDbContext
    {
        public AuthenticationContext(DbContextOptions options) : base(options)
        {

        }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Calculation> Calculations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CalculationViewModel> CalculationViewModels { get; set; }
    }
}

